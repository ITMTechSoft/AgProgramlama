using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemClassLib.Models
{


    public class PlanningSideBLL
    {
        #region Program Paramter

        public PlanEntity Planner { get; set; }

        public List<OperationEntity> OperationList { get; set; }
        public Action<string> CloseConnection { get; set; }
        public List<MachineEntity> MachineList { get; set; }
        #endregion

        #region Socket Parameters

        public Socket ClinetSocket = null;
        public DateTime LastConnectionTime { get; set; }

        public string PlanningIP { get; set; }
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
   
        public byte[] Buffer = new byte[8192];
        public List<string>  LogMessage { get; set; }

        public bool? ConnectionStatus = null;

        #endregion

        CheckedListBox MachineCheckList;
        CheckedListBox OperationCheckList;

        public void RefeshComboBox(CheckedListBox CheckList, List<MachineSocket> MachineList)
        {
            CheckList.Invoke(new Action(() =>
            {
                CheckList.Items.Clear();
                MachineList.ForEach(r => CheckList.Items.Add(r.MachineIP));


            }));
        }


        public PlanningSideBLL()
        {
            this.LogMessage = new List<string>();
        }

        public PlanningSideBLL(Socket clinetSocket, int IntervalTime = 4000):this()
        {
            try
            {
                this.ClinetSocket = clinetSocket;
                this.LastConnectionTime = DateTime.Now;
            }
            catch (Exception ex)
            {
            }
        }

        public PlanningSideBLL(string ServerIP, string ServerPort, string PlanerName,string UserName, string Password, 
            CheckedListBox machineCheckList,
            CheckedListBox operationCheckList) : this()
        {
            this.ServerIP = ServerIP;
            this.ServerPort = ServerPort;


            this.Planner = new PlanEntity(PlanerName, UserName, Password);

            this.MachineCheckList = machineCheckList;
            this.OperationCheckList = operationCheckList;

        }


        public bool StartServerConnection()
        {
            // Connect to a remote device.  
            try
            {
                IPEndPoint ServerPoint = new IPEndPoint(IPAddress.Parse(this.ServerIP), Convert.ToUInt16(this.ServerPort));
                this.ClinetSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                this.ClinetSocket.BeginConnect(ServerPoint, new AsyncCallback(ConnectCallback), this);
                this.ConnectionStatus = true;
                return true;
            }
            catch (Exception e)
            {
                LogMessage.Add(e.ToString());
            }
            return false;
        }

        public bool StopApplicationConnection()
        {
            try
            {
                this.ClinetSocket.Close();
                this.ConnectionStatus = false;
                return true;
            }
            catch (Exception e)
            {
                LogMessage.Add(e.ToString());
                return false;
            }
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                var ClientConnect = (PlanningSideBLL)ar.AsyncState;

                // Complete the connection.  
                ClientConnect.ClinetSocket.EndConnect(ar);

                if (ClientConnect.ClinetSocket != null && ClientConnect.ClinetSocket.RemoteEndPoint != null)
                    ClientConnect.PlanningIP = ClientConnect.ClinetSocket.ToString();

                ClientConnect.ClinetSocket.BeginReceive(this.Buffer, 0, ClientConnect.Buffer.Length, SocketFlags.None, new AsyncCallback(OnClinetRecive), ClientConnect);

                var PlanningPacket = new PlanPacket();
                PlanningPacket.ActionType = PlanningActions.FirstConnect;
                PlanningPacket.Planer.PlanerName = ClientConnect.Planner.PlanerName;
                PlanningPacket.Planer.UserName = ClientConnect.Planner.UserName;
                PlanningPacket.Planer.Password = ClientConnect.Planner.Password;

                ClientConnect.SendAction(PlanningPacket);

            }
            catch (Exception e)
            {
                LogMessage.Add(e.ToString());
            }
        }


        public void OnClinetRecive(IAsyncResult ar)
        {
            try
            {
                var SocketClient = ar.AsyncState as PlanningSideBLL;
                if (SocketClient.ClinetSocket.Blocking)
                {
                    int ByteReads = SocketClient.ClinetSocket.EndReceive(ar);
                    if (ByteReads > 0)
                    {
                        var PlanPacket = Models.PlanPacket.GetPacket(SocketClient.Buffer);
                        SocketClient.Buffer =  new byte[8192];
                        switch (PlanPacket.ActionType)
                        {
                            case PlanningActions.InvalidConnection:
                                this.CloseConnection("Invalid User Name Or  Password .... ");
                                ConnectionStatus = false;
                                break;
                            case PlanningActions.ConnectionStatus:
                                ConnectionStatus = PlanPacket.ConnectionStatus;
                                break;
                            case PlanningActions.ReciveOperationList:
                                this.OperationList = PlanPacket.TaskOperationList;
                                OperationCheckList.Invoke(new Action(() =>
                                {
                                    OperationCheckList.Items.Clear();
                                    if (OperationList.Count == 0)
                                        OperationList.Clear();
                                    else
                                        OperationList.ForEach(r => OperationCheckList.Items.Add(r.ToString()));


                                }));
                                break;
                            case PlanningActions.MachineList:
                                this.MachineList = PlanPacket.MachineTypeList;
                                MachineCheckList.Invoke(new Action(() =>
                                {
                                    MachineCheckList.Items.Clear();


                                    MachineList.ForEach(r => MachineCheckList.Items.Add(r.MachineType));


                                }));
                                break;

                            default:
                                break;
                        }

                        if (!ConnectionStatus == false)
                            SocketClient.ClinetSocket.BeginReceive(this.Buffer, 0, SocketClient.Buffer.Length, SocketFlags.None, new AsyncCallback(OnClinetRecive), SocketClient);
                        else
                            LogMessage.Add("Connection Closed ....");


                    }
                }
            }
            catch (Exception e)
            {
                LogMessage.Add(e.ToString());
            }
        }


        public void SendAction(PlanPacket planningPacket)
        {
            try
            {
                if (this.ClinetSocket.Blocking)
                {
                    this.ClinetSocket.Send(planningPacket.GetByte());
                }
            }
            catch (Exception Ex)
            {
                LogMessage.Add(Ex.ToString());
            }
           
        }


    }
}
