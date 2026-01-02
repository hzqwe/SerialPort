namespace SerialPortDebugAssistant
{
    partial class Form1
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_SendData = new System.Windows.Forms.Button();
            this.textBox_Receive = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_OpenSerial = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Parity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_SerialPort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_SendData);
            this.groupBox3.Controls.Add(this.textBox_Receive);
            this.groupBox3.Location = new System.Drawing.Point(674, 461);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(683, 420);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "接收数据";
            // 
            // button_SendData
            // 
            this.button_SendData.Location = new System.Drawing.Point(33, 348);
            this.button_SendData.Name = "button_SendData";
            this.button_SendData.Size = new System.Drawing.Size(592, 47);
            this.button_SendData.TabIndex = 3;
            this.button_SendData.Text = "发送数据";
            this.button_SendData.UseVisualStyleBackColor = true;
            this.button_SendData.Click += new System.EventHandler(this.button_SendData_Click);
            // 
            // textBox_Receive
            // 
            this.textBox_Receive.Location = new System.Drawing.Point(33, 27);
            this.textBox_Receive.Multiline = true;
            this.textBox_Receive.Name = "textBox_Receive";
            this.textBox_Receive.Size = new System.Drawing.Size(592, 301);
            this.textBox_Receive.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_Send);
            this.groupBox2.Location = new System.Drawing.Point(674, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(683, 420);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "发送数据";
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(33, 50);
            this.textBox_Send.Multiline = true;
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(592, 301);
            this.textBox_Send.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_OpenSerial);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.comboBox_StopBits);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboBox_Parity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_DataBits);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_BaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox_SerialPort);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(52, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 779);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // button_OpenSerial
            // 
            this.button_OpenSerial.Location = new System.Drawing.Point(44, 645);
            this.button_OpenSerial.Name = "button_OpenSerial";
            this.button_OpenSerial.Size = new System.Drawing.Size(398, 65);
            this.button_OpenSerial.TabIndex = 12;
            this.button_OpenSerial.Text = "打开串口";
            this.button_OpenSerial.UseVisualStyleBackColor = true;
            this.button_OpenSerial.Click += new System.EventHandler(this.button_OpenSerial_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(257, 517);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 22);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "16进制";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(44, 517);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 22);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "字符串";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // comboBox_StopBits
            // 
            this.comboBox_StopBits.FormattingEnabled = true;
            this.comboBox_StopBits.Location = new System.Drawing.Point(163, 412);
            this.comboBox_StopBits.Name = "comboBox_StopBits";
            this.comboBox_StopBits.Size = new System.Drawing.Size(202, 26);
            this.comboBox_StopBits.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(41, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "停止位";
            // 
            // comboBox_Parity
            // 
            this.comboBox_Parity.FormattingEnabled = true;
            this.comboBox_Parity.Location = new System.Drawing.Point(163, 319);
            this.comboBox_Parity.Name = "comboBox_Parity";
            this.comboBox_Parity.Size = new System.Drawing.Size(202, 26);
            this.comboBox_Parity.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "校验位";
            // 
            // comboBox_DataBits
            // 
            this.comboBox_DataBits.FormattingEnabled = true;
            this.comboBox_DataBits.Location = new System.Drawing.Point(163, 231);
            this.comboBox_DataBits.Name = "comboBox_DataBits";
            this.comboBox_DataBits.Size = new System.Drawing.Size(202, 26);
            this.comboBox_DataBits.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "数据位";
            // 
            // comboBox_BaudRate
            // 
            this.comboBox_BaudRate.FormattingEnabled = true;
            this.comboBox_BaudRate.Location = new System.Drawing.Point(163, 144);
            this.comboBox_BaudRate.Name = "comboBox_BaudRate";
            this.comboBox_BaudRate.Size = new System.Drawing.Size(202, 26);
            this.comboBox_BaudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率";
            // 
            // comboBox_SerialPort
            // 
            this.comboBox_SerialPort.FormattingEnabled = true;
            this.comboBox_SerialPort.Location = new System.Drawing.Point(163, 63);
            this.comboBox_SerialPort.Name = "comboBox_SerialPort";
            this.comboBox_SerialPort.Size = new System.Drawing.Size(202, 26);
            this.comboBox_SerialPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1409, 917);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "串口助手";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_Receive;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_SerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button_SendData;
        private System.Windows.Forms.Button button_OpenSerial;
    }
}

