
namespace ServerSideApplication
{
    partial class ServerSideApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.CB_ServerIps = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GB_Machine = new System.Windows.Forms.CheckedListBox();
            this.CB_Ports = new System.Windows.Forms.NumericUpDown();
            this.GB_Planning = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.CB_PlanningPort = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_StopServer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.Passwrod = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CB_Ports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CB_PlanningPort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Ip :";
            // 
            // CB_ServerIps
            // 
            this.CB_ServerIps.FormattingEnabled = true;
            this.CB_ServerIps.Location = new System.Drawing.Point(103, 12);
            this.CB_ServerIps.Name = "CB_ServerIps";
            this.CB_ServerIps.Size = new System.Drawing.Size(279, 28);
            this.CB_ServerIps.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Machine Ports :";
            // 
            // GB_Machine
            // 
            this.GB_Machine.FormattingEnabled = true;
            this.GB_Machine.Location = new System.Drawing.Point(21, 170);
            this.GB_Machine.Name = "GB_Machine";
            this.GB_Machine.Size = new System.Drawing.Size(150, 114);
            this.GB_Machine.TabIndex = 3;
            // 
            // CB_Ports
            // 
            this.CB_Ports.Location = new System.Drawing.Point(46, 117);
            this.CB_Ports.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.CB_Ports.Name = "CB_Ports";
            this.CB_Ports.Size = new System.Drawing.Size(83, 27);
            this.CB_Ports.TabIndex = 4;
            this.CB_Ports.Value = new decimal(new int[] {
            8899,
            0,
            0,
            0});
            // 
            // GB_Planning
            // 
            this.GB_Planning.FormattingEnabled = true;
            this.GB_Planning.Location = new System.Drawing.Point(225, 170);
            this.GB_Planning.Name = "GB_Planning";
            this.GB_Planning.Size = new System.Drawing.Size(150, 114);
            this.GB_Planning.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Machines";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Planning";
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(46, 290);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(94, 29);
            this.btn_StartServer.TabIndex = 8;
            this.btn_StartServer.Text = "Start Server";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
            // 
            // CB_PlanningPort
            // 
            this.CB_PlanningPort.Location = new System.Drawing.Point(263, 117);
            this.CB_PlanningPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.CB_PlanningPort.Name = "CB_PlanningPort";
            this.CB_PlanningPort.Size = new System.Drawing.Size(83, 27);
            this.CB_PlanningPort.TabIndex = 10;
            this.CB_PlanningPort.Value = new decimal(new int[] {
            9988,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(252, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Planning Ports :";
            // 
            // btn_StopServer
            // 
            this.btn_StopServer.Enabled = false;
            this.btn_StopServer.Location = new System.Drawing.Point(252, 290);
            this.btn_StopServer.Name = "btn_StopServer";
            this.btn_StopServer.Size = new System.Drawing.Size(94, 29);
            this.btn_StopServer.TabIndex = 11;
            this.btn_StopServer.Text = "Stop Server";
            this.btn_StopServer.UseVisualStyleBackColor = true;
            this.btn_StopServer.Click += new System.EventHandler(this.btn_StopServer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "User Name";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(103, 50);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(92, 27);
            this.UserName.TabIndex = 13;
            this.UserName.Text = "A";
            // 
            // Passwrod
            // 
            this.Passwrod.Location = new System.Drawing.Point(283, 50);
            this.Passwrod.Name = "Passwrod";
            this.Passwrod.Size = new System.Drawing.Size(92, 27);
            this.Passwrod.TabIndex = 15;
            this.Passwrod.Text = "A";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(202, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Passwrod";
            // 
            // ServerSideApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(409, 336);
            this.Controls.Add(this.Passwrod);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_StopServer);
            this.Controls.Add(this.CB_PlanningPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_StartServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GB_Planning);
            this.Controls.Add(this.CB_Ports);
            this.Controls.Add(this.GB_Machine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_ServerIps);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Name = "ServerSideApp";
            this.Text = "ServerSideApp";
            this.Load += new System.EventHandler(this.ServerSideApp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CB_Ports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CB_PlanningPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_ServerIps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox GB_Machine;
        private System.Windows.Forms.NumericUpDown CB_Ports;
        private System.Windows.Forms.CheckedListBox GB_Planning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.NumericUpDown CB_PlanningPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_StopServer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox Passwrod;
        private System.Windows.Forms.Label label7;
    }
}