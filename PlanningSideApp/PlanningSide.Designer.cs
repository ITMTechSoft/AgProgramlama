
namespace PlanningSideApp
{
    partial class PlanningSide
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
            this.components = new System.ComponentModel.Container();
            this.CB_Ports = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_ServerIps = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.btn_StartConnection = new System.Windows.Forms.Button();
            this.SystemStatus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GB_Machine = new System.Windows.Forms.CheckedListBox();
            this.btn_SendNewOperation = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OrderAmount = new System.Windows.Forms.NumericUpDown();
            this.OrderNo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GB_Operation = new System.Windows.Forms.CheckedListBox();
            this.btn_ClearOperations = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.btn_CloseConnection = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.PlanerName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.CB_Ports)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAmount)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Ports
            // 
            this.CB_Ports.Location = new System.Drawing.Point(118, 48);
            this.CB_Ports.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.CB_Ports.Name = "CB_Ports";
            this.CB_Ports.Size = new System.Drawing.Size(136, 27);
            this.CB_Ports.TabIndex = 8;
            this.CB_Ports.Value = new decimal(new int[] {
            9988,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ports :";
            // 
            // CB_ServerIps
            // 
            this.CB_ServerIps.FormattingEnabled = true;
            this.CB_ServerIps.Location = new System.Drawing.Point(118, 11);
            this.CB_ServerIps.Name = "CB_ServerIps";
            this.CB_ServerIps.Size = new System.Drawing.Size(136, 28);
            this.CB_ServerIps.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server Ip :";
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(118, 120);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(136, 27);
            this.UserName.TabIndex = 9;
            this.UserName.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "User Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Password :";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(118, 156);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(136, 27);
            this.Password.TabIndex = 12;
            this.Password.Text = "A";
            // 
            // btn_StartConnection
            // 
            this.btn_StartConnection.Location = new System.Drawing.Point(9, 256);
            this.btn_StartConnection.Name = "btn_StartConnection";
            this.btn_StartConnection.Size = new System.Drawing.Size(96, 50);
            this.btn_StartConnection.TabIndex = 13;
            this.btn_StartConnection.Text = "Start Connect";
            this.btn_StartConnection.UseVisualStyleBackColor = true;
            this.btn_StartConnection.Click += new System.EventHandler(this.btn_StartConnection_Click);
            // 
            // SystemStatus
            // 
            this.SystemStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.SystemStatus.ForeColor = System.Drawing.Color.Maroon;
            this.SystemStatus.Location = new System.Drawing.Point(9, 186);
            this.SystemStatus.Name = "SystemStatus";
            this.SystemStatus.Size = new System.Drawing.Size(245, 67);
            this.SystemStatus.TabIndex = 17;
            this.SystemStatus.Text = "Program Is Stop";
            this.SystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(260, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(454, 351);
            this.tabControl1.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GB_Machine);
            this.tabPage1.Controls.Add(this.btn_SendNewOperation);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.OrderAmount);
            this.tabPage1.Controls.Add(this.OrderNo);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(446, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Machines";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // GB_Machine
            // 
            this.GB_Machine.FormattingEnabled = true;
            this.GB_Machine.Location = new System.Drawing.Point(3, 3);
            this.GB_Machine.Name = "GB_Machine";
            this.GB_Machine.Size = new System.Drawing.Size(440, 158);
            this.GB_Machine.TabIndex = 7;
            // 
            // btn_SendNewOperation
            // 
            this.btn_SendNewOperation.Location = new System.Drawing.Point(99, 269);
            this.btn_SendNewOperation.Name = "btn_SendNewOperation";
            this.btn_SendNewOperation.Size = new System.Drawing.Size(149, 29);
            this.btn_SendNewOperation.TabIndex = 6;
            this.btn_SendNewOperation.Text = "Insert Jobs";
            this.btn_SendNewOperation.UseVisualStyleBackColor = true;
            this.btn_SendNewOperation.Click += new System.EventHandler(this.btn_SendNewOperation_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Amount";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Order No.";
            // 
            // OrderAmount
            // 
            this.OrderAmount.Location = new System.Drawing.Point(99, 225);
            this.OrderAmount.Name = "OrderAmount";
            this.OrderAmount.Size = new System.Drawing.Size(150, 27);
            this.OrderAmount.TabIndex = 2;
            // 
            // OrderNo
            // 
            this.OrderNo.Location = new System.Drawing.Point(99, 174);
            this.OrderNo.Name = "OrderNo";
            this.OrderNo.Size = new System.Drawing.Size(150, 27);
            this.OrderNo.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GB_Operation);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(446, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Operation Lists";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GB_Operation
            // 
            this.GB_Operation.FormattingEnabled = true;
            this.GB_Operation.Location = new System.Drawing.Point(3, 3);
            this.GB_Operation.Name = "GB_Operation";
            this.GB_Operation.Size = new System.Drawing.Size(440, 312);
            this.GB_Operation.TabIndex = 6;
            // 
            // btn_ClearOperations
            // 
            this.btn_ClearOperations.Location = new System.Drawing.Point(9, 312);
            this.btn_ClearOperations.Name = "btn_ClearOperations";
            this.btn_ClearOperations.Size = new System.Drawing.Size(245, 29);
            this.btn_ClearOperations.TabIndex = 3;
            this.btn_ClearOperations.Text = "Delete All Operations";
            this.btn_ClearOperations.UseVisualStyleBackColor = true;
            this.btn_ClearOperations.Click += new System.EventHandler(this.btn_ClearOperations_Click);
            // 
            // btn_CloseConnection
            // 
            this.btn_CloseConnection.Location = new System.Drawing.Point(158, 256);
            this.btn_CloseConnection.Name = "btn_CloseConnection";
            this.btn_CloseConnection.Size = new System.Drawing.Size(96, 50);
            this.btn_CloseConnection.TabIndex = 19;
            this.btn_CloseConnection.Text = "Close Connection";
            this.btn_CloseConnection.UseVisualStyleBackColor = true;
            this.btn_CloseConnection.Click += new System.EventHandler(this.btn_CloseConnection_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Planer Name";
            // 
            // PlanerName
            // 
            this.PlanerName.Location = new System.Drawing.Point(118, 84);
            this.PlanerName.Name = "PlanerName";
            this.PlanerName.Size = new System.Drawing.Size(136, 27);
            this.PlanerName.TabIndex = 20;
            this.PlanerName.Text = "Planer 1";
            // 
            // PlanningSide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(713, 352);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_ClearOperations);
            this.Controls.Add(this.PlanerName);
            this.Controls.Add(this.btn_CloseConnection);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.SystemStatus);
            this.Controls.Add(this.btn_StartConnection);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.CB_Ports);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CB_ServerIps);
            this.Controls.Add(this.label1);
            this.Name = "PlanningSide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlanningSide";
            this.Load += new System.EventHandler(this.PlanningSide_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CB_Ports)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderAmount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown CB_Ports;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CB_ServerIps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button btn_StartConnection;
        private System.Windows.Forms.Label SystemStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_SendNewOperation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown OrderAmount;
        private System.Windows.Forms.TextBox OrderNo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_ClearOperations;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.CheckedListBox GB_Machine;
        private System.Windows.Forms.CheckedListBox GB_Operation;
        private System.Windows.Forms.Button btn_CloseConnection;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PlanerName;
    }
}