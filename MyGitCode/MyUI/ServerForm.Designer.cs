namespace MyUI
{
    partial class ServerForm
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
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.txtMsg = new System.Windows.Forms.RichTextBox();
            this.cboIpPort = new System.Windows.Forms.ComboBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(41, 34);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(107, 25);
            this.txtIP.TabIndex = 0;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(176, 33);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 25);
            this.txtPort.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(353, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始监听";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(41, 90);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(530, 141);
            this.txtLog.TabIndex = 3;
            this.txtLog.Text = "";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(41, 271);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(530, 151);
            this.txtMsg.TabIndex = 4;
            this.txtMsg.Text = "";
            // 
            // cboIpPort
            // 
            this.cboIpPort.FormattingEnabled = true;
            this.cboIpPort.Location = new System.Drawing.Point(512, 33);
            this.cboIpPort.Name = "cboIpPort";
            this.cboIpPort.Size = new System.Drawing.Size(121, 23);
            this.cboIpPort.TabIndex = 5;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(593, 415);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "发送消息";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 450);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.cboIpPort);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Name = "ServerForm";
            this.Text = "服务端";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.RichTextBox txtMsg;
        private System.Windows.Forms.ComboBox cboIpPort;
        private System.Windows.Forms.Button btnSend;
    }
}