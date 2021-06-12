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

namespace PlanningSideApp
{
    public partial class PlanningSide : Form
    {

        public PlanningSideBLL Planning { get; set; }
        public int OperationCounter { get; set; }



      

        public PlanningSide()
        {
            InitializeComponent();
            Planning = new PlanningSideBLL();
        }

        static public void RefeshComboBox(CheckedListBox CheckList , List<MachineSocket> MachineList)
        {
            CheckList.Invoke(new Action(() =>
            {
                CheckList.Items.Clear();
                MachineList.ForEach(r => CheckList.Items.Add(r.MachineIP));


            }));
        }

        private void PlanningSide_Load(object sender, EventArgs e)
        {
            SystemUtils.GetSystemPorts().ForEach(r => CB_ServerIps.Items.Add(r));
            CB_ServerIps.SelectedIndex = 0;
        }

        private void btn_StartConnection_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(UserName.Text) && !string.IsNullOrEmpty(Password.Text))
                {
                    Planning = new PlanningSideBLL(
                        CB_ServerIps.SelectedItem.ToString(),
                        CB_Ports.Value.ToString(),
                        PlanerName.Text,
                        UserName.Text,
                        Password.Text,
                        GB_Machine,
                        GB_Operation);

                    Planning.CloseConnection = this.CloseConnection;
                    SystemStatus.Text = "Start connecting Loading....";
                    Thread.Sleep(1000);
                    if (Planning.StartServerConnection())
                    {
                        btn_StartConnection.Enabled = false;
                        btn_CloseConnection.Enabled = true;
                        SystemStatus.Text = "Application Connected";
                    }
                }
                else
                {
                    SystemStatus.Text = "Please Enter User Name Or Password";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error to Start Server");
            }
           
          
        }

        private void ReceiveClientSocket(IAsyncResult ar)
        {
            SystemStatus.Invoke(new Action(() =>
            {
                SystemStatus.Text = Planning.LogMessage.Last();

            }));
            GB_Machine.Invoke(new Action(() =>
            {
                GB_Machine.Items.Clear();
                Planning.MachineList.ForEach(r => GB_Machine.Items.Add(r.Machine_Name));
                

              }));
            GB_Operation.Invoke(new Action(() =>
            {
                GB_Operation.Items.Clear();
                Planning.OperationList.ForEach(r => GB_Operation.Items.Add(r.Order_Number + " - " + r.Order_Amount));
            

            }));

         


        }

        public int Coutner { get; set; }

        private void btn_SendNewOperation_Click(object sender, EventArgs e)
        {
            if (Planning.ConnectionStatus !=true)
            {
                SystemStatus.Text = "Program Is Not Connected";
                return;
            }
            if (string.IsNullOrEmpty( OrderNo.Text) || OrderAmount.Value == 0)
            {
                SystemStatus.Text = "Insert Order No and Amount";
                return;
            }
            MachineEntity Machine = new MachineEntity();
            
            if (GB_Machine.SelectedItem !=null && Planning.MachineList !=null)
                Machine.MachineType = GB_Machine.SelectedItem.ToString();
            else
            {
                SystemStatus.Text = "Choose Machine Before Start ...";
                return;
            }

            Coutner++;
            var PlanningPacket = new PlanPacket();
            PlanningPacket.ActionType = PlanningActions.SendOperation;
            PlanningPacket.Operation = new OperationEntity(PlanerName.Text + "-" + OrderNo.Text + Coutner, Convert.ToInt32(OrderAmount.Value));
            PlanningPacket.Machine = Machine;

            Planning.SendAction(PlanningPacket);


        }

        private void btn_ClearOperations_Click(object sender, EventArgs e)
        {
            if (Planning.ConnectionStatus != true)
            {
                SystemStatus.Text = "Program Is Not Connected";
                return;
            }

            //send Clear packet
            var PlanningPacket = new PlanPacket();
            PlanningPacket.ActionType = PlanningActions.DeleteOperation;


            Planning.SendAction(PlanningPacket);
        }

        private void btn_CloseConnection_Click(object sender, EventArgs e)
        {
            CloseConnection("Connection Closed...");

        }

        private void CloseConnection(string Message)
        {
            try
            {
                if (Planning.StopApplicationConnection())
                {
                    btn_StartConnection.Invoke(new Action(() =>
                    {
                        btn_StartConnection.Enabled = true;
                    }));
                    btn_CloseConnection.Invoke(new Action(() =>
                    {
                        btn_CloseConnection.Enabled = false;
                    }));

                    SystemStatus.Invoke(new Action(() =>
                    {
                        SystemStatus.Text = Message;
                    }));

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error to Stop Server", ex.ToString());
            }
        }

    }
}
