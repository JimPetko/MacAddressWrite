namespace MacAddressWrite
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbx_UserName = new System.Windows.Forms.TextBox();
            this.tbx_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pan_Connect = new System.Windows.Forms.Panel();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.pan_Serial = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.cbx_BaudRate = new System.Windows.Forms.ComboBox();
            this.btn_SerialConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_SerialPorts = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel_DatabaseConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel_SerialConnection = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_WriteToEEPROM = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_MacAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_SerialMonitor = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtb_SerialContent = new System.Windows.Forms.RichTextBox();
            this.bwrk_Monitor = new System.ComponentModel.BackgroundWorker();
            this.pan_Connect.SuspendLayout();
            this.pan_Serial.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_UserName
            // 
            this.tbx_UserName.Location = new System.Drawing.Point(6, 40);
            this.tbx_UserName.Name = "tbx_UserName";
            this.tbx_UserName.Size = new System.Drawing.Size(208, 20);
            this.tbx_UserName.TabIndex = 0;
            this.tbx_UserName.Text = "UserName";
            // 
            // tbx_Password
            // 
            this.tbx_Password.Location = new System.Drawing.Point(6, 66);
            this.tbx_Password.Name = "tbx_Password";
            this.tbx_Password.PasswordChar = '*';
            this.tbx_Password.Size = new System.Drawing.Size(208, 20);
            this.tbx_Password.TabIndex = 1;
            this.tbx_Password.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please Login to Mac Address Database:";
            // 
            // pan_Connect
            // 
            this.pan_Connect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_Connect.Controls.Add(this.btn_Connect);
            this.pan_Connect.Controls.Add(this.label1);
            this.pan_Connect.Controls.Add(this.tbx_UserName);
            this.pan_Connect.Controls.Add(this.tbx_Password);
            this.pan_Connect.Location = new System.Drawing.Point(12, 12);
            this.pan_Connect.Name = "pan_Connect";
            this.pan_Connect.Size = new System.Drawing.Size(233, 143);
            this.pan_Connect.TabIndex = 3;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(6, 92);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(91, 23);
            this.btn_Connect.TabIndex = 3;
            this.btn_Connect.Text = "Connect to DB";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // pan_Serial
            // 
            this.pan_Serial.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_Serial.Controls.Add(this.label4);
            this.pan_Serial.Controls.Add(this.cbx_BaudRate);
            this.pan_Serial.Controls.Add(this.btn_SerialConnect);
            this.pan_Serial.Controls.Add(this.label2);
            this.pan_Serial.Controls.Add(this.cbx_SerialPorts);
            this.pan_Serial.Location = new System.Drawing.Point(251, 12);
            this.pan_Serial.Name = "pan_Serial";
            this.pan_Serial.Size = new System.Drawing.Size(192, 143);
            this.pan_Serial.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Baud Rate :";
            // 
            // cbx_BaudRate
            // 
            this.cbx_BaudRate.FormattingEnabled = true;
            this.cbx_BaudRate.Location = new System.Drawing.Point(67, 59);
            this.cbx_BaudRate.Name = "cbx_BaudRate";
            this.cbx_BaudRate.Size = new System.Drawing.Size(114, 21);
            this.cbx_BaudRate.TabIndex = 5;
            // 
            // btn_SerialConnect
            // 
            this.btn_SerialConnect.Location = new System.Drawing.Point(6, 101);
            this.btn_SerialConnect.Name = "btn_SerialConnect";
            this.btn_SerialConnect.Size = new System.Drawing.Size(104, 35);
            this.btn_SerialConnect.TabIndex = 4;
            this.btn_SerialConnect.Text = "Establish Serial Interface";
            this.btn_SerialConnect.UseVisualStyleBackColor = true;
            this.btn_SerialConnect.Click += new System.EventHandler(this.btn_SerialConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select Serial Connection Port";
            // 
            // cbx_SerialPorts
            // 
            this.cbx_SerialPorts.FormattingEnabled = true;
            this.cbx_SerialPorts.Location = new System.Drawing.Point(6, 26);
            this.cbx_SerialPorts.Name = "cbx_SerialPorts";
            this.cbx_SerialPorts.Size = new System.Drawing.Size(174, 21);
            this.cbx_SerialPorts.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel_DatabaseConnection,
            this.StatusLabel_SerialConnection});
            this.statusStrip1.Location = new System.Drawing.Point(0, 284);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(449, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel_DatabaseConnection
            // 
            this.statusLabel_DatabaseConnection.ForeColor = System.Drawing.Color.Red;
            this.statusLabel_DatabaseConnection.Image = global::MacAddressWrite.Properties.Resources._4417104_database_icon;
            this.statusLabel_DatabaseConnection.Name = "statusLabel_DatabaseConnection";
            this.statusLabel_DatabaseConnection.Size = new System.Drawing.Size(146, 17);
            this.statusLabel_DatabaseConnection.Text = "Database Disconnected";
            // 
            // StatusLabel_SerialConnection
            // 
            this.StatusLabel_SerialConnection.ActiveLinkColor = System.Drawing.Color.Red;
            this.StatusLabel_SerialConnection.ForeColor = System.Drawing.Color.Magenta;
            this.StatusLabel_SerialConnection.Image = global::MacAddressWrite.Properties.Resources._8686218_ic_fluent_serial_port_filled_icon;
            this.StatusLabel_SerialConnection.Name = "StatusLabel_SerialConnection";
            this.StatusLabel_SerialConnection.Size = new System.Drawing.Size(126, 17);
            this.StatusLabel_SerialConnection.Text = "Serial Disconnected";
            // 
            // btn_WriteToEEPROM
            // 
            this.btn_WriteToEEPROM.Enabled = false;
            this.btn_WriteToEEPROM.Location = new System.Drawing.Point(20, 238);
            this.btn_WriteToEEPROM.Name = "btn_WriteToEEPROM";
            this.btn_WriteToEEPROM.Size = new System.Drawing.Size(423, 23);
            this.btn_WriteToEEPROM.TabIndex = 6;
            this.btn_WriteToEEPROM.Text = "Write to EEPROM";
            this.btn_WriteToEEPROM.UseVisualStyleBackColor = true;
            this.btn_WriteToEEPROM.Click += new System.EventHandler(this.btn_WriteToEEPROM_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lab_MacAddress);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(13, 162);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 70);
            this.panel1.TabIndex = 7;
            // 
            // lab_MacAddress
            // 
            this.lab_MacAddress.AutoSize = true;
            this.lab_MacAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_MacAddress.Location = new System.Drawing.Point(3, 29);
            this.lab_MacAddress.Name = "lab_MacAddress";
            this.lab_MacAddress.Size = new System.Drawing.Size(204, 20);
            this.lab_MacAddress.TabIndex = 1;
            this.lab_MacAddress.Text = "00 : 00 : 00 : 00 : 00 : 00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Next Available MAC Address:";
            // 
            // btn_SerialMonitor
            // 
            this.btn_SerialMonitor.Location = new System.Drawing.Point(342, 166);
            this.btn_SerialMonitor.Name = "btn_SerialMonitor";
            this.btn_SerialMonitor.Size = new System.Drawing.Size(98, 23);
            this.btn_SerialMonitor.TabIndex = 8;
            this.btn_SerialMonitor.Text = "Serial Monitor >>";
            this.btn_SerialMonitor.UseVisualStyleBackColor = true;
            this.btn_SerialMonitor.Click += new System.EventHandler(this.btn_SerialMonitor_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rtb_SerialContent);
            this.panel2.Location = new System.Drawing.Point(450, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 249);
            this.panel2.TabIndex = 9;
            // 
            // rtb_SerialContent
            // 
            this.rtb_SerialContent.Location = new System.Drawing.Point(3, 3);
            this.rtb_SerialContent.Name = "rtb_SerialContent";
            this.rtb_SerialContent.Size = new System.Drawing.Size(411, 243);
            this.rtb_SerialContent.TabIndex = 0;
            this.rtb_SerialContent.Text = "";
            // 
            // bwrk_Monitor
            // 
            this.bwrk_Monitor.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwrk_Monitor_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 306);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_SerialMonitor);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_WriteToEEPROM);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pan_Serial);
            this.Controls.Add(this.pan_Connect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Mac Address Writer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.pan_Connect.ResumeLayout(false);
            this.pan_Connect.PerformLayout();
            this.pan_Serial.ResumeLayout(false);
            this.pan_Serial.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_UserName;
        private System.Windows.Forms.TextBox tbx_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pan_Connect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Panel pan_Serial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_SerialPorts;
        private System.Windows.Forms.Button btn_SerialConnect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_DatabaseConnection;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel_SerialConnection;
        private System.Windows.Forms.Button btn_WriteToEEPROM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lab_MacAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbx_BaudRate;
        private System.Windows.Forms.Button btn_SerialMonitor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtb_SerialContent;
        private System.ComponentModel.BackgroundWorker bwrk_Monitor;
    }
}

