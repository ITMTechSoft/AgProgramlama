using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SystemClassLib.Models;
using SystemClassLib.Utils;

namespace MachineSideApp
{
    public partial class MachineSideApp : Form
    {
        public MachineSocket Machine { get; set; }
        public Task MachineWorkTask { get; set; }
        public MachineSideApp()
        {
            InitializeComponent();
        }

        private void MachineSideApp_Load(object sender, EventArgs e)
        {
            SystemUtils.GetSystemPorts().ForEach(r => CB_ServerIps.Items.Add(r));
            CB_ServerIps.SelectedIndex = 0;
            btn_CloseConnection.Enabled = false;
            CB_Ports.Value = 8899;
        }

        private void Btn_StartConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(MachineName.Text) && !string.IsNullOrEmpty(MachineType.Text) && Speed.Value > 0)
                {
                    Machine = new MachineSocket(
                        CB_ServerIps.SelectedItem.ToString(),
                        CB_Ports.Value.ToString(),
                        MachineName.Text,
                        MachineType.Text,
                        Convert.ToInt32(Speed.Value));
                    if (Machine.StartServerConnection())
                    {
                        Btn_StartConnect.Enabled = false;
                        btn_CloseConnection.Enabled = true;
                        Machine.SendMachineStatus(MachineAction.Connect);
                        SystemStatus.Text = "Application Connected";
                        MachineWorkTask = Task.Factory.StartNew(() => { RefeshInterface(); });
                    }
                }
                else
                {
                    SystemStatus.Text = "Please Machine Information Before Start ....";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error to Start Server");
            }
        }

        private void RefeshInterface()
        {
            do
            {
                if (Machine.CurrentOperation != null)
                {
                    Machine_Status.Invoke(new Action(() =>
                    {
                        if (Machine.Status == MachineStatus.Busy)
                        {
                            Machine_Status.Text = MachineStatus.Busy.ToString();
                            Machine_Status.BackColor = Color.Red;
                            SystemCounter.Text = (int)((Machine.OperationCounter * 100) / Machine.CurrentOperation.Order_Amount) + " %";
                            SystemStatus.Text = "Start Order No:" + Environment.NewLine+ Machine.CurrentOperation.Order_Number;
                        }
                        else
                        {
                            Machine_Status.Text = MachineStatus.Empty.ToString();
                            Machine_Status.BackColor = Color.DarkGreen;
                            SystemStatus.Text = "Start Order No: --- ";
                        }
                    }));
                }
                Thread.Sleep(1000);
            } while (Machine.ConnectionStatus);
        }

        private void btn_CloseConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (Machine.StopApplicationConnection())
                {
                    Btn_StartConnect.Enabled = true;
                    btn_CloseConnection.Enabled = false;
                    SystemStatus.Text = "Application Closed";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to Stop Server", ex.ToString());
            }
        }
    }
}
