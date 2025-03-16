using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;

namespace mcproxy
{

    public partial class mainForm : Form
    {

        private Thread receiveThread;
        private Thread forwardThread;
        private static bool btnRunFlag;
        private static bool threadRunFlag;
        private static ConcurrentQueue<byte[]> msgQueue;
        private static int msgCount;
        private static int msgByte;

        private static int msgCountps;
        private static int msgByteps;

        private static bool isMuticast;

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.Text = "mcProxy" + string.Format(" [{0:r}]", System.IO.File.GetLastWriteTime(this.GetType().Assembly.Location));
            comboBoxMuticastInterface.Items.Clear();
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in networkInterfaces)
            {
                // 获取每个网络接口的 IP 地址
                IPInterfaceProperties ipProperties = ni.GetIPProperties();
                if (ni.SupportsMulticast == true)
                {
                    foreach (var unicastAddress in ipProperties.UnicastAddresses)
                    {
                        // 只打印 IPv4 地址
                        if (unicastAddress.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            Console.WriteLine($"接口名称: {ni.Name}");
                            Console.WriteLine($"IP 地址: {unicastAddress.Address}");
                            Console.WriteLine(new string('-', 50));

                            if (!unicastAddress.Address.ToString().StartsWith("169"))
                            {
                                comboBoxMuticastInterface.Items.Add(unicastAddress.Address.ToString());
                            }
                        }
                    }
                }

            }
            comboBoxMuticastInterface.SelectedIndex = 0;

            receiveThread = null;
            forwardThread = null;
            threadRunFlag = false;
            btnRunFlag = false;
            msgQueue = new ConcurrentQueue<byte[]>();
        }

        private HashSet<IPEndPoint> GetDstInfo()
        {

            HashSet<IPEndPoint> server = new HashSet<IPEndPoint>();
            try
            {

                string text = textBoxDstinfo.Text.Trim();
                text = text.Replace("\r\n", "\n");

                var list = text.Split('\n');
                foreach (var entry in list)
                {

                    // 分解 IP 地址和端口
                    string[] parts = entry.Split(':');
                    if (parts.Length != 2)
                    {
                        throw new FormatException("输入格式不正确,应该是 'IP:Port'");
                    }

                    string ipString = parts[0];
                    int port = int.Parse(parts[1]);

                    // 创建 IPAddress 实例
                    IPAddress ipAddress = IPAddress.Parse(ipString);

                    // 创建 IPEndPoint 实例
                    IPEndPoint endpoint = new IPEndPoint(ipAddress, port);

                    server.Add(endpoint);

                    // 打印结果
                    Console.WriteLine($"IP 地址: {endpoint.Address}, 端口: {endpoint.Port}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
                server.Clear();
            }

            return server;
        }

        static void ReceiveData(object arg)
        {
            try
            {
                muticastInfo info = (muticastInfo)arg;
                Console.WriteLine(info.ToString());

                // 创建UdpClient并绑定到指定端口
                UdpClient udpServer = new UdpClient();

                // 获取底层 Socket
                Socket socket = udpServer.Client;

                // 设置端口复用
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

                //设置接收超时
                socket.ReceiveTimeout = 10;

                // 绑定到端口
                socket.Bind(new IPEndPoint(IPAddress.Parse(info.ifAddr), info.muticastPort));

                // 加入组播组
                IPAddress multicastAddress = IPAddress.Parse("127.0.0.1");/*占位否则会提示使用未初始化的局部变量*/
                if (isMuticast)
                {
                    multicastAddress = IPAddress.Parse(info.muticastAddr);
                    udpServer.JoinMulticastGroup(multicastAddress, IPAddress.Parse(info.ifAddr));
                }

                // 接收数据
                IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, info.muticastPort);

                while (threadRunFlag)
                {
                    try
                    {
                        // 接收数据
                        byte[] data = udpServer.Receive(ref remoteEP);
                        //Console.Write("*");
                        //Console.WriteLine(BitConverter.ToString(data));

                        // 统计数据
                        msgCount++;
                        msgByte += data.Length;

                        //统计速率
                        msgByteps += data.Length;
                        msgCountps++;

                        msgQueue.Enqueue(data);

                    }
                    catch (SocketException ex)
                    {
                        //Console.WriteLine($"接收错误: {ex.Message}");
                        continue;
                    }
                }
                // 离开组播组
                if(isMuticast)
                {
                    udpServer.DropMulticastGroup(multicastAddress);
                }
                
                // 关闭
                udpServer.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }           
            Console.WriteLine("Thread ReceiveData exit");

        }

        static void ForwardData(object arg)
        {
            HashSet<IPEndPoint> serverlist = (HashSet<IPEndPoint>)arg;

            UdpClient udpClient = new UdpClient();
            List<IPEndPoint> txIPEndPoints = new List<IPEndPoint>();

            foreach (var server in serverlist)/*转换到list，遍历性能list优于哈希表*/
            {
                Console.WriteLine(server.ToString());
                txIPEndPoints.Add(server);
            }
            byte[] data;
            while (threadRunFlag)
            {
                if (msgQueue.TryDequeue(out data))
                {
                    // 转发到IP列表
                    foreach (var tx in txIPEndPoints)
                    {
                        udpClient.Send(data, data.Length, tx);
                    }
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
            Console.WriteLine("Thread ForwardData exit");
        }
        private void buttonCtl_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnRunFlag == false)
                {
                    if ((receiveThread == null) && (forwardThread == null))
                    {
                        var server = GetDstInfo();
                        if (server.Count == 0)
                        {
                            return;
                        }

                        if (!IPAddress.TryParse(textBoxMuticastIP.Text, out _))
                        {
                            throw new Exception("监听的参数有误");
                        }
                        muticastInfo info = new muticastInfo(comboBoxMuticastInterface.Text, textBoxMuticastIP.Text, (int)numericUpDownMuticastPort.Value);

                        isMuticast = checkBoxMuticast.Checked;

                        msgCount = 0;
                        msgByte = 0;

                        msgCountps = 0;
                        msgCountps = 0;

                        // 创建接收和转发线程
                        receiveThread = new Thread(ReceiveData);
                        forwardThread = new Thread(ForwardData);

                        threadRunFlag = true;

                        receiveThread.IsBackground = true;
                        forwardThread.IsBackground = true;

                        receiveThread.Start(info);
                        forwardThread.Start(server);


                        Console.WriteLine("done");
                        buttonCtl.Text = "停止";
                        btnRunFlag = true;
                        labelStat.Text = "运行中";
                    }
                    else
                    {
                        Console.WriteLine("线程已经运行!");
                    }

                }
                else
                {

                    threadRunFlag = false;
                    Thread.Sleep(100);/*等待线程自行了断*/

                    if (receiveThread != null)
                    {
                        receiveThread.Join();
                        //receiveThread.Abort(); ;
                        receiveThread = null;
                    }

                    if (forwardThread != null)
                    {
                        forwardThread.Join();
                        //forwardThread.Abort();
                        forwardThread = null;
                    }
                    buttonCtl.Text = "启动";
                    labelStat.Text = "未运行";
                    btnRunFlag = false;
                    msgQueue = new ConcurrentQueue<byte[]>();/*清空队列*/

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timerReflash_Tick(object sender, EventArgs e)
        {
            labelMsgItem.Text = $" {msgCount}  包 , {msgByte} 字节";
            labelPs.Text = $" {msgCountps} 包/秒 , {msgByteps} 字节/秒";
            msgCountps = 0;
            msgByteps = 0;

            labelMsgItem.Refresh();
            labelPs.Refresh();
        }
    }

    public class muticastInfo
    {
        public string ifAddr { get; }
        public string muticastAddr { get; }
        public int muticastPort { get; }

        public muticastInfo(string ifAddr, string muticastAddr, int muticastPort)
        {
            this.ifAddr = ifAddr;
            this.muticastAddr = muticastAddr;
            this.muticastPort = muticastPort;
        }

        public override string ToString()
        {
            return $"ifaddr: {ifAddr}, listen: {muticastAddr}:{muticastPort}";
        }
    }
}
