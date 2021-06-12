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

namespace ServerSideApplication
{
    public partial class ServerSideApp : Form
    {
        public ServerBLL CurrentServer { get; set; }
        public Task StartServerLog { get; set; }
        public bool ServerStatus { get; set; }

        public ServerSideApp()
        {
            InitializeComponent();
        }

        private void ServerSideApp_Load(object sender, EventArgs e)
        {
            SystemUtils.GetSystemPorts().ForEach(r => CB_ServerIps.Items.Add(r));
            CB_ServerIps.SelectedIndex = 0;
        }

        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            StartServerAction();
        }

        public void StartServerAction()
        {
            try
            {
                CurrentServer = new ServerBLL(CB_ServerIps.SelectedItem.ToString(), CB_Ports.Value.ToString(), CB_PlanningPort.Value.ToString(), null);
                CurrentServer.ServerUserName = UserName.Text;
                CurrentServer.ServerPassword = Passwrod.Text;
                if (ServerStatus = CurrentServer.StartTCPServer())
                {
                    btn_StartServer.Enabled = false;
                    btn_StopServer.Enabled = true;
                    StartServerLog = Task.Factory.StartNew(() => { ReceiveClientSocket(); });
                }
                else
                {
                    btn_StartServer.Enabled = true;
                    btn_StopServer.Enabled = false;
                    MessageBox.Show("Server Faild To Start");
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show( Ex.ToString() , "Error to Start Server");
            }
        }

        private void btn_StopServer_Click(object sender, EventArgs e)
        {
            try
            {
                if (ServerStatus = CurrentServer.StopTCPServer())
                {
                    btn_StartServer.Enabled = true;
                    btn_StopServer.Enabled = false;
                }
                else
                {
                    btn_StartServer.Enabled = false;
                    btn_StopServer.Enabled = true;
                    MessageBox.Show("Server Faild To Stop");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error to Stop Server", Ex.Message);
            }
        }

      

  

        public void ReceiveClientSocket()
        {
            do
            {
                GB_Machine.Invoke(new Action(() =>
                {
                    GB_Machine.Items.Clear();
                    foreach (var item in CurrentServer.MachineSokets)
                        GB_Machine.Items.Add(string.Format("{0} {1}",item.Machine_Name, item.MachineType));
                }));

                GB_Planning.Invoke(new Action(() =>
                {
                    GB_Planning.Items.Clear();
                    foreach (var item in CurrentServer.PlanningSokets)
                        if (item.Planner != null)
                            GB_Planning.Items.Add(item.Planner.PlanerName);
                }));
                Thread.Sleep(1000);
            } while (ServerStatus);
            


        }
    }
}
