namespace SLMPClient
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.boxSLMP = new System.Windows.Forms.GroupBox();
            this.lstDevice = new System.Windows.Forms.ComboBox();
            this.btnRead = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.txtDeviceNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.boxData = new System.Windows.Forms.GroupBox();
            this.txtData = new System.Windows.Forms.TextBox();
            this.boxConnection = new System.Windows.Forms.GroupBox();
            this.boxSLMP.SuspendLayout();
            this.boxData.SuspendLayout();
            this.boxConnection.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP Address:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(69, 19);
            this.txtIPAddress.MaxLength = 15;
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.Text = "192.168.3.39";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(69, 42);
            this.txtPort.MaxLength = 15;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "8000";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(175, 22);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(107, 36);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // boxSLMP
            // 
            this.boxSLMP.Controls.Add(this.lstDevice);
            this.boxSLMP.Controls.Add(this.btnRead);
            this.boxSLMP.Controls.Add(this.label5);
            this.boxSLMP.Controls.Add(this.label4);
            this.boxSLMP.Controls.Add(this.txtPoints);
            this.boxSLMP.Controls.Add(this.txtDeviceNo);
            this.boxSLMP.Controls.Add(this.label3);
            this.boxSLMP.Location = new System.Drawing.Point(7, 91);
            this.boxSLMP.Name = "boxSLMP";
            this.boxSLMP.Size = new System.Drawing.Size(292, 95);
            this.boxSLMP.TabIndex = 3;
            this.boxSLMP.TabStop = false;
            this.boxSLMP.Text = "SLMP";
            // 
            // lstDevice
            // 
            this.lstDevice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.lstDevice.FormattingEnabled = true;
            this.lstDevice.Items.AddRange(new object[] {
            "D",
            "W",
            "R"});
            this.lstDevice.Location = new System.Drawing.Point(69, 13);
            this.lstDevice.Name = "lstDevice";
            this.lstDevice.Size = new System.Drawing.Size(100, 21);
            this.lstDevice.TabIndex = 1;
            this.lstDevice.SelectedIndexChanged += new System.EventHandler(this.lstDevice_SelectedIndexChanged);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(175, 29);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(107, 36);
            this.btnRead.TabIndex = 2;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Points:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "DeviceNo:";
            // 
            // txtPoints
            // 
            this.txtPoints.Location = new System.Drawing.Point(69, 62);
            this.txtPoints.MaxLength = 5;
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.Size = new System.Drawing.Size(100, 20);
            this.txtPoints.TabIndex = 1;
            this.txtPoints.TextChanged += new System.EventHandler(this.txtPoints_TextChanged);
            // 
            // txtDeviceNo
            // 
            this.txtDeviceNo.Location = new System.Drawing.Point(69, 38);
            this.txtDeviceNo.MaxLength = 5;
            this.txtDeviceNo.Name = "txtDeviceNo";
            this.txtDeviceNo.Size = new System.Drawing.Size(100, 20);
            this.txtDeviceNo.TabIndex = 1;
            this.txtDeviceNo.TextChanged += new System.EventHandler(this.txtDeviceNo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Device:";
            // 
            // boxData
            // 
            this.boxData.Controls.Add(this.txtData);
            this.boxData.Location = new System.Drawing.Point(7, 192);
            this.boxData.Name = "boxData";
            this.boxData.Size = new System.Drawing.Size(292, 169);
            this.boxData.TabIndex = 4;
            this.boxData.TabStop = false;
            this.boxData.Text = "Data";
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(9, 20);
            this.txtData.Multiline = true;
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtData.Size = new System.Drawing.Size(273, 143);
            this.txtData.TabIndex = 0;
            // 
            // boxConnection
            // 
            this.boxConnection.Controls.Add(this.txtIPAddress);
            this.boxConnection.Controls.Add(this.label1);
            this.boxConnection.Controls.Add(this.btnConnect);
            this.boxConnection.Controls.Add(this.label2);
            this.boxConnection.Controls.Add(this.txtPort);
            this.boxConnection.Location = new System.Drawing.Point(7, 9);
            this.boxConnection.Name = "boxConnection";
            this.boxConnection.Size = new System.Drawing.Size(292, 76);
            this.boxConnection.TabIndex = 5;
            this.boxConnection.TabStop = false;
            this.boxConnection.Text = "Connection";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 370);
            this.Controls.Add(this.boxData);
            this.Controls.Add(this.boxSLMP);
            this.Controls.Add(this.boxConnection);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "SLMP Client";
            this.boxSLMP.ResumeLayout(false);
            this.boxSLMP.PerformLayout();
            this.boxData.ResumeLayout(false);
            this.boxData.PerformLayout();
            this.boxConnection.ResumeLayout(false);
            this.boxConnection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox boxSLMP;
        private System.Windows.Forms.ComboBox lstDevice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPoints;
        private System.Windows.Forms.TextBox txtDeviceNo;
        private System.Windows.Forms.GroupBox boxData;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.GroupBox boxConnection;
    }
}

