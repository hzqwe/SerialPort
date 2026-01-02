namespace SerialPortDebugTool
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtRegPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Login = new System.Windows.Forms.Button();
            this.txtRegConfirmPwd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRegPwd
            // 
            this.txtRegPwd.Location = new System.Drawing.Point(402, 200);
            this.txtRegPwd.Name = "txtRegPwd";
            this.txtRegPwd.PasswordChar = '*';
            this.txtRegPwd.Size = new System.Drawing.Size(286, 28);
            this.txtRegPwd.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "新密码";
            // 
            // txtRegName
            // 
            this.txtRegName.Location = new System.Drawing.Point(402, 136);
            this.txtRegName.Name = "txtRegName";
            this.txtRegName.Size = new System.Drawing.Size(286, 28);
            this.txtRegName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(334, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "用户名";
            // 
            // button_Login
            // 
            this.button_Login.Location = new System.Drawing.Point(348, 359);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(321, 75);
            this.button_Login.TabIndex = 5;
            this.button_Login.Text = "注册";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.btnRegSubmit_Click);
            // 
            // txtRegConfirmPwd
            // 
            this.txtRegConfirmPwd.Location = new System.Drawing.Point(402, 270);
            this.txtRegConfirmPwd.Name = "txtRegConfirmPwd";
            this.txtRegConfirmPwd.PasswordChar = '*';
            this.txtRegConfirmPwd.Size = new System.Drawing.Size(286, 28);
            this.txtRegConfirmPwd.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "确认密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("宋体", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(73, 637);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "返回";
            this.label4.Click += new System.EventHandler(this.btnRegClose_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(405, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 48);
            this.label5.TabIndex = 13;
            this.label5.Text = "注册界面";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 714);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRegConfirmPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRegPwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRegName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Login);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRegPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRegName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Login;
        private System.Windows.Forms.TextBox txtRegConfirmPwd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}