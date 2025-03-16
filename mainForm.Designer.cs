namespace mcproxy
{
    partial class mainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.comboBoxMuticastInterface = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelStat = new System.Windows.Forms.Label();
            this.buttonCtl = new System.Windows.Forms.Button();
            this.checkBoxMuticast = new System.Windows.Forms.CheckBox();
            this.numericUpDownMuticastPort = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMuticastIP = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxDstinfo = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelPs = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMsgItem = new System.Windows.Forms.Label();
            this.labelMsgRxInfo = new System.Windows.Forms.Label();
            this.timerReflash = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMuticastPort)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxMuticastInterface
            // 
            this.comboBoxMuticastInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMuticastInterface.FormattingEnabled = true;
            this.comboBoxMuticastInterface.Location = new System.Drawing.Point(41, 14);
            this.comboBoxMuticastInterface.Name = "comboBoxMuticastInterface";
            this.comboBoxMuticastInterface.Size = new System.Drawing.Size(120, 20);
            this.comboBoxMuticastInterface.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "接口";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelStat);
            this.groupBox1.Controls.Add(this.buttonCtl);
            this.groupBox1.Controls.Add(this.checkBoxMuticast);
            this.groupBox1.Controls.Add(this.numericUpDownMuticastPort);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxMuticastIP);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxMuticastInterface);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(624, 40);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "监听参数";
            // 
            // labelStat
            // 
            this.labelStat.AutoSize = true;
            this.labelStat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelStat.Location = new System.Drawing.Point(569, 16);
            this.labelStat.Name = "labelStat";
            this.labelStat.Size = new System.Drawing.Size(41, 12);
            this.labelStat.TabIndex = 7;
            this.labelStat.Text = "未运行";
            // 
            // buttonCtl
            // 
            this.buttonCtl.Location = new System.Drawing.Point(475, 12);
            this.buttonCtl.Name = "buttonCtl";
            this.buttonCtl.Size = new System.Drawing.Size(87, 23);
            this.buttonCtl.TabIndex = 5;
            this.buttonCtl.Text = "启动";
            this.buttonCtl.UseVisualStyleBackColor = true;
            this.buttonCtl.Click += new System.EventHandler(this.buttonCtl_Click);
            // 
            // checkBoxMuticast
            // 
            this.checkBoxMuticast.AutoSize = true;
            this.checkBoxMuticast.Location = new System.Drawing.Point(268, 16);
            this.checkBoxMuticast.Name = "checkBoxMuticast";
            this.checkBoxMuticast.Size = new System.Drawing.Size(72, 16);
            this.checkBoxMuticast.TabIndex = 6;
            this.checkBoxMuticast.Text = "组播地址";
            this.checkBoxMuticast.UseVisualStyleBackColor = true;
            // 
            // numericUpDownMuticastPort
            // 
            this.numericUpDownMuticastPort.Location = new System.Drawing.Point(202, 14);
            this.numericUpDownMuticastPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownMuticastPort.Name = "numericUpDownMuticastPort";
            this.numericUpDownMuticastPort.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownMuticastPort.TabIndex = 5;
            this.numericUpDownMuticastPort.Value = new decimal(new int[] {
            5538,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "端口";
            // 
            // textBoxMuticastIP
            // 
            this.textBoxMuticastIP.Location = new System.Drawing.Point(346, 14);
            this.textBoxMuticastIP.Name = "textBoxMuticastIP";
            this.textBoxMuticastIP.Size = new System.Drawing.Size(123, 21);
            this.textBoxMuticastIP.TabIndex = 3;
            this.textBoxMuticastIP.Text = "239.255.0.215";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxDstinfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(624, 281);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "转发参数";
            // 
            // textBoxDstinfo
            // 
            this.textBoxDstinfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDstinfo.Location = new System.Drawing.Point(3, 17);
            this.textBoxDstinfo.Multiline = true;
            this.textBoxDstinfo.Name = "textBoxDstinfo";
            this.textBoxDstinfo.Size = new System.Drawing.Size(618, 261);
            this.textBoxDstinfo.TabIndex = 0;
            this.textBoxDstinfo.Text = "127.0.0.1:6000\r\n127.0.0.1:6001";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelPs);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.labelMsgItem);
            this.groupBox3.Controls.Add(this.labelMsgRxInfo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 263);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(624, 58);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "状态";
            // 
            // labelPs
            // 
            this.labelPs.AutoSize = true;
            this.labelPs.Location = new System.Drawing.Point(71, 33);
            this.labelPs.Name = "labelPs";
            this.labelPs.Size = new System.Drawing.Size(29, 12);
            this.labelPs.TabIndex = 3;
            this.labelPs.Text = "null";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "速率统计:";
            // 
            // labelMsgItem
            // 
            this.labelMsgItem.AutoSize = true;
            this.labelMsgItem.Location = new System.Drawing.Point(71, 17);
            this.labelMsgItem.Name = "labelMsgItem";
            this.labelMsgItem.Size = new System.Drawing.Size(29, 12);
            this.labelMsgItem.TabIndex = 1;
            this.labelMsgItem.Text = "null";
            // 
            // labelMsgRxInfo
            // 
            this.labelMsgRxInfo.AutoSize = true;
            this.labelMsgRxInfo.Location = new System.Drawing.Point(6, 17);
            this.labelMsgRxInfo.Name = "labelMsgRxInfo";
            this.labelMsgRxInfo.Size = new System.Drawing.Size(59, 12);
            this.labelMsgRxInfo.TabIndex = 0;
            this.labelMsgRxInfo.Text = "接收统计:";
            // 
            // timerReflash
            // 
            this.timerReflash.Enabled = true;
            this.timerReflash.Interval = 1000;
            this.timerReflash.Tick += new System.EventHandler(this.timerReflash_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 321);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 360);
            this.Name = "mainForm";
            this.Text = "mcProxy";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMuticastPort)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMuticastInterface;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxMuticastIP;
        private System.Windows.Forms.NumericUpDown numericUpDownMuticastPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxDstinfo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonCtl;
        private System.Windows.Forms.Timer timerReflash;
        private System.Windows.Forms.Label labelMsgItem;
        private System.Windows.Forms.Label labelMsgRxInfo;
        private System.Windows.Forms.Label labelPs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxMuticast;
        private System.Windows.Forms.Label labelStat;
    }
}

