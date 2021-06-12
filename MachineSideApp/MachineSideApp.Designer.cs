
namespace MachineSideApp
{
    partial class MachineSideApp
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
            this.CB_Ports = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_ServerIps = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MachineName = new System.Windows.Forms.TextBox();
            this.Speed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MachineType = new System.Windows.Forms.TextBox();
            this.Btn_StartConnect = new System.Windows.Forms.Button();
            this.Machine_Status = new System.Windows.Forms.Label();
            this.SystemCounter = new System.Windows.Forms.Label();
            this.btn_CloseConnection = new System.Windows.Forms.Button();
            this.SystemStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CB_Ports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Ports
            // 
            this.CB_Ports.Location = new System.Drawing.Point(149, 56);
            this.CB_Ports.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.CB_Ports.Name = "CB_Ports";
            this.CB_Ports.Size = new System.Drawing.Size(151, 27);
            this.CB_Ports.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ports :";
            // 
            // CB_ServerIps
            // 
            this.CB_ServerIps.FormattingEnabled = true;
            this.CB_ServerIps.Location = new System.Drawing.Point(149, 13);
            this.CB_ServerIps.Name = "CB_ServerIps";
            this.CB_ServerIps.Size = new System.Drawing.Size(151, 28);
            this.CB_ServerIps.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Server Ip :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Machine Name:";
            // 
            // MachineName
            // 
            this.MachineName.Location = new System.Drawing.Point(149, 102);
            this.MachineName.Name = "MachineName";
            this.MachineName.Size = new System.Drawing.Size(151, 27);
            this.MachineName.TabIndex = 13;
            this.MachineName.Text = "Singer";
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(149, 188);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(151, 27);
            this.Speed.TabIndex = 16;
            this.Speed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Production Speed :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Machine Type:";
            // 
            // MachineType
            // 
            this.MachineType.Location = new System.Drawing.Point(149, 144);
            this.MachineType.Name = "MachineType";
            this.MachineType.Size = new System.Drawing.Size(151, 27);
            this.MachineType.TabIndex = 17;
            this.MachineType.Text = "CNC";
            // 
            // Btn_StartConnect
            // 
            this.Btn_StartConnect.Location = new System.Drawing.Point(6, 231);
            this.Btn_StartConnect.Name = "Btn_StartConnect";
            this.Btn_StartConnect.Size = new System.Drawing.Size(129, 29);
            this.Btn_StartConnect.TabIndex = 19;
            this.Btn_StartConnect.Text = "Start Connect";
            this.Btn_StartConnect.UseVisualStyleBackColor = true;
            this.Btn_StartConnect.Click += new System.EventHandler(this.Btn_StartConnect_Click);
            // 
            // Machine_Status
            // 
            this.Machine_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Machine_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Machine_Status.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Machine_Status.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Machine_Status.Location = new System.Drawing.Point(322, 133);
            this.Machine_Status.Margin = new System.Windows.Forms.Padding(10);
            this.Machine_Status.Name = "Machine_Status";
            this.Machine_Status.Size = new System.Drawing.Size(146, 82);
            this.Machine_Status.TabIndex = 21;
            this.Machine_Status.Text = "Empty";
            this.Machine_Status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SystemCounter
            // 
            this.SystemCounter.AutoSize = true;
            this.SystemCounter.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SystemCounter.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SystemCounter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SystemCounter.Location = new System.Drawing.Point(358, 224);
            this.SystemCounter.Name = "SystemCounter";
            this.SystemCounter.Size = new System.Drawing.Size(75, 46);
            this.SystemCounter.TabIndex = 22;
            this.SystemCounter.Text = "0 %";
            // 
            // btn_CloseConnection
            // 
            this.btn_CloseConnection.Location = new System.Drawing.Point(183, 231);
            this.btn_CloseConnection.Name = "btn_CloseConnection";
            this.btn_CloseConnection.Size = new System.Drawing.Size(117, 29);
            this.btn_CloseConnection.TabIndex = 23;
            this.btn_CloseConnection.Text = "Close Connection";
            this.btn_CloseConnection.UseVisualStyleBackColor = true;
            this.btn_CloseConnection.Click += new System.EventHandler(this.btn_CloseConnection_Click);
            // 
            // SystemStatus
            // 
            this.SystemStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SystemStatus.ForeColor = System.Drawing.Color.Maroon;
            this.SystemStatus.Location = new System.Drawing.Point(322, 13);
            this.SystemStatus.Name = "SystemStatus";
            this.SystemStatus.Size = new System.Drawing.Size(148, 110);
            this.SystemStatus.TabIndex = 24;
            this.SystemStatus.Text = "Program Is Stop";
            this.SystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MachineSideApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(498, 302);
            this.Controls.Add(this.SystemStatus);
            this.Controls.Add(this.btn_CloseConnection);
            this.Controls.Add(this.SystemCounter);
            this.Controls.Add(this.Machine_Status);
            this.Controls.Add(this.Btn_StartConnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MachineType);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MachineName);
            this.Controls.Add(this.CB_Ports);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_ServerIps);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Name = "MachineSideApp";
            this.Text = "MachineSideApp";
            this.Load += new System.EventHandler(this.MachineSideApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CB_Ports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Speed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown CB_Ports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_ServerIps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MachineName;
        private System.Windows.Forms.NumericUpDown Speed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MachineType;
        private System.Windows.Forms.Button Btn_StartConnect;
        private System.Windows.Forms.Label Machine_Status;
        private System.Windows.Forms.Label SystemCounter;
        private System.Windows.Forms.Button btn_CloseConnection;
        private System.Windows.Forms.Label SystemStatus;
    }
}