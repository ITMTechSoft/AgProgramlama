using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemClassLib.Models
{
    public class ServerBLL
    {
        #region property
        public string Server_TCPIP { get; set; }
        public string MachineServer_Port { get; set; }
        public string PlanningServer_Port { get; set; }
        public Socket TCPServerMachineSocket { get; set; }
        public Socket TCPServerPlanningSocket { get; set; }
        public SafeThreadList<MachineSocket> MachineSokets { get; set; }
        public SafeThreadList<PlanningSideBLL> PlanningSokets { get; set; }

        public SafeThreadList<OperationBLL> Operations { set; get; }
        public SafeThreadList<string> LogsBuffer { get; set; }
        public bool ConnectionStatus { get; set; }

        public string ServerUserName = "A";
        public string ServerPassword = "A";

        private Task MachineOperationStart;
     
        #endregion

        #region Constractors
        public ServerBLL()
        {
            MachineSokets = new SafeThreadList<MachineSocket>();
            PlanningSokets = new SafeThreadList<PlanningSideBLL>();
            // LogsBuffer = new SafeThreadList<string>();
            Operations = new SafeThreadList<OperationBLL>();
            TCPServerMachineSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TCPServerMachineSocket.Blocking = false;
            TCPServerPlanningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TCPServerPlanningSocket.Blocking = false;
        }

        public ServerBLL(string ServerIp, string MachinePort,string PlanningPort, AsyncCallback receiveClientSocket) : this()
        {
            this.Server_TCPIP = ServerIp;
            this.MachineServer_Port = MachinePort;
            this.PlanningServer_Port = PlanningPort;
           // this.RefeshInterface = receiveClientSocket;
         //   BufferThreadPool = 40;
            LogsBuffer = new SafeThreadList<string>();
        }

      
        #endregion

        #region Open Close Server Soket
        void ConfigureClientTcpSocket(Socket tcpSocket)
        {
            tcpSocket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
            // Disable the Nagle Algorithm for this tcp socket.
            tcpSocket.NoDelay = true;

            // Set the receive buffer size to 8k
            tcpSocket.ReceiveBufferSize = 8192;

            // Set the timeout for synchronous receive methods to
            // 1 second (1000 milliseconds.)
            tcpSocket.ReceiveTimeout = 1000;

            // Set the send buffer size to 8k.
            tcpSocket.SendBufferSize = 8192;

            // Set the timeout for synchronous send methods
            // to 1 second (1000 milliseconds.)
            tcpSocket.SendTimeout = 1000;

            // Set the Time To Live (TTL) to 42 router hops.
            tcpSocket.Ttl = 42;
        }

        void ConfigureServerTcpSocket(Socket TCPServerSocket)
        {
            TCPServerSocket.Listen(10000);
            TCPServerSocket.ReceiveBufferSize = 8192;
            // Set the timeout for synchronous receive methods to
            // 1 second (1000 milliseconds.)
            TCPServerSocket.ReceiveTimeout = 1000;
            // Set the send buffer size to 8k.
            TCPServerSocket.SendBufferSize = 8192;
            // Set the timeout for synchronous send methods
            // to 1 second (1000 milliseconds.)
            TCPServerSocket.SendTimeout = 1000;
            // Set the Time To Live (TTL) to 42 router hops.
            TCPServerSocket.Ttl = 42;
            TCPServerSocket.NoDelay = true;
            TCPServerSocket.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
        }

        public bool StartTCPServer()
        {
            TCPServerMachineSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TCPServerPlanningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TCPServerMachineSocket.Blocking = false;
            TCPServerPlanningSocket.Blocking = false;
            if (!TCPServerMachineSocket.Blocking && !TCPServerPlanningSocket.Blocking)
            {

                TCPServerMachineSocket.Blocking = true;
                TCPServerMachineSocket.Close();
                TCPServerPlanningSocket.Blocking = true;
                TCPServerPlanningSocket.Close();
                IPEndPoint _IPMachineServerPoint = new IPEndPoint(IPAddress.Parse(this.Server_TCPIP), Convert.ToUInt16(this.MachineServer_Port));
                IPEndPoint _IPPlanningServerPoint = new IPEndPoint(IPAddress.Parse(this.Server_TCPIP), Convert.ToUInt16(this.PlanningServer_Port));
                TCPServerMachineSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TCPServerMachineSocket.Bind(_IPMachineServerPoint);
                ConfigureServerTcpSocket(TCPServerMachineSocket);

                TCPServerPlanningSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TCPServerPlanningSocket.Bind(_IPPlanningServerPoint);
                ConfigureServerTcpSocket(TCPServerPlanningSocket);

                TCPServerPlanningSocket.BeginAccept(new AsyncCallback(OnPlanningClinentAccept), TCPServerPlanningSocket);

                TCPServerMachineSocket.BeginAccept(new AsyncCallback(OnMachineClinentAccept), TCPServerMachineSocket);

                ConnectionStatus = true;

                MachineOperationStart = Task.Factory.StartNew(()=> { MachineTaskStart(); });
                
                return true;
            }
            return false;
        }

        public void MachineTaskStart()
        {
            do
            {
                foreach (var item in this.Operations.Where(r=>r.IsStarted ==false))
                {
                    var Machine = this.MachineSokets.Where(r => r.MachineType == item.TargetMachine.MachineType 
                    && r.Status == MachineStatus.Empty).FirstOrDefault();
                    if (Machine != null)
                    {
                        var Packet = new MachinePacket();
                        Packet.ActionType = MachineAction.StartOperation;
                        Packet.CurrentOperation.Order_Number = item.Order_Number;
                        Packet.CurrentOperation.Order_Amount = item.Order_Amount;
                        Packet.PlanningIP = item.PlanningIP;
                        item.IsStarted = true;

                        item.TargetMachine= Machine; 
                        
                        Machine.SendAction(Packet);
                        item.StartTime = DateTime.Now;
                        Machine.Status = MachineStatus.Busy;
                    }
                }
                Thread.Sleep(1000);
            } while (ConnectionStatus);
        }

        public void OnMachineClinentAccept(IAsyncResult ar)
        {
            try
            {
                try
                {
                    var SoketClient = new MachineSocket((Socket)ar.AsyncState);
                    SoketClient.ClinetSocket = SoketClient.ClinetSocket.EndAccept(ar);
                    ConfigureClientTcpSocket(SoketClient.ClinetSocket);

                    if (TCPServerMachineSocket.Blocking)
                    {
                        ///Start Recive Session for the Client
                        SoketClient.ClinetSocket.BeginReceive(SoketClient.Buffer, 0, SoketClient.Buffer.Length, SocketFlags.None, new AsyncCallback(OnMachineClientRecive), SoketClient);

                        /// begin recive
                        if (SoketClient.ClinetSocket != null && SoketClient.ClinetSocket.RemoteEndPoint != null)
                            SoketClient.MachineIP = SoketClient.ClinetSocket.RemoteEndPoint.ToString();


                        MachineSokets.Add(SoketClient);
                  
                     //   IAsyncResult tempResult = RefeshInterface.BeginInvoke(null, null, this);
                     //   RefeshInterface.Invoke(tempResult);
                    }
                }
                catch (Exception ex)
                {
                    LogsBuffer.Add(ex.ToString());
                }
                /// This condition to Avoid the Error when close the Server
                if (TCPServerMachineSocket.Blocking)
                {
                    TCPServerMachineSocket.BeginAccept(new AsyncCallback(OnMachineClinentAccept), TCPServerMachineSocket);
                }
            }
            catch (Exception ex)
            {
                LogsBuffer.Add(ex.ToString());
            }
        }
        public void OnMachineClientRecive(IAsyncResult ar)
        {
            try
            {
                var SocketClient = ar.AsyncState as MachineSocket;
                if (SocketClient.ClinetSocket.Blocking)
                {
                    int ByteReads = SocketClient.ClinetSocket.EndReceive(ar);
                    if (ByteReads > 0)
                    {

                        var Packet = MachinePacket.GetPacket(SocketClient.Buffer);
                        SocketClient.Buffer = new byte[8192];
                        switch (Packet.ActionType)
                        {
                            case MachineAction.Connect:
                                SocketClient.Status = MachineStatus.Empty;
                                SocketClient.Machine_Name = Packet.Machine.Machine_Name;
                                SocketClient.MachineType = Packet.Machine.MachineType;
                                SocketClient.Speed = Packet.Machine.Speed;
                                SocketClient.Status = Packet.Machine.Status;
                                foreach (var item in PlanningSokets)
                                    SendingCurrentMachines(item);

                                break;
                            case MachineAction.StartOperation:
                                SocketClient.Status = Packet.Machine.Status;
                                SendingCurrentOperation(Packet.PlanningIP);
                                break;
                            case MachineAction.FinishOperation:
                                SocketClient.Status = Packet.Machine.Status;
                                foreach (var item in Operations)
                                    if (item.PlanningIP == Packet.PlanningIP && item.TargetMachine.Machine_Name == SocketClient.Machine_Name && item.IsStarted)
                                        item.EndTime = DateTime.Now;
                                SendingCurrentOperation(Packet.PlanningIP);
                                break;
                            default:
                                break;
                        }
                        ///Start ReOpen Revice 
                        SocketClient.ClinetSocket.BeginReceive(SocketClient.Buffer, 0, SocketClient.Buffer.Length, SocketFlags.None, new AsyncCallback(OnMachineClientRecive), SocketClient);
                    }
                }
            }
            
            catch (Exception e)
            {
                LogsBuffer.Add("MakistusServer_OnClinetRecive => OnClinetRecive: ");
            }
        }


        public void OnPlanningClinentAccept(IAsyncResult ar)
        {
            try
            {
                try
                {
                    var SoketClient = new PlanningSideBLL((Socket)ar.AsyncState);
                    SoketClient.ClinetSocket = SoketClient.ClinetSocket.EndAccept(ar);
                    ConfigureClientTcpSocket(SoketClient.ClinetSocket);

                    if (TCPServerPlanningSocket.Blocking)
                    {
     
                        /// begin recive
                        if (SoketClient.ClinetSocket != null && SoketClient.ClinetSocket.RemoteEndPoint != null)
                            SoketClient.PlanningIP = SoketClient.ClinetSocket.RemoteEndPoint.ToString();
                        
                        PlanningSokets.Add(SoketClient);

                        ///Start Recive Session for the Client
                        SoketClient.ClinetSocket.BeginReceive(SoketClient.Buffer, 0, SoketClient.Buffer.Length, SocketFlags.None, new AsyncCallback(OnPlanningClientRecive), SoketClient);


                    }
                }
                catch (Exception ex)
                {
                    LogsBuffer.Add("BC_TCPServer=> OnClinentAccept:  " + ex.Message);
                }
                /// This condition to Avoid the Error when close the Server
                if (TCPServerPlanningSocket.Blocking)
                {
                    TCPServerPlanningSocket.BeginAccept(new AsyncCallback(OnPlanningClinentAccept), TCPServerPlanningSocket);
                }
            }
            catch (Exception ex)
            {
                LogsBuffer.Add("BC_TCPServer.OnClinentAccept=> Error Genel:  " + "Non");
            }
        }
        public void OnPlanningClientRecive(IAsyncResult ar)
        {
            try
            {
                bool ReConnectStatus = true;
                var SocketClient = ar.AsyncState as PlanningSideBLL;
                if (SocketClient.ClinetSocket.Blocking)
                {
                    int ByteReads = SocketClient.ClinetSocket.EndReceive(ar);
                    if (ByteReads > 0)
                    {
                        try
                        {
                            var PlanPacket = Models.PlanPacket.GetPacket(SocketClient.Buffer);
                            SocketClient.Buffer = new byte[8192];
                            switch (PlanPacket.ActionType)
                            {
                                case PlanningActions.FirstConnect:
                                    /// Check Login For Planning
                                    if (ServerUserName != PlanPacket.Planer.UserName && ServerPassword != PlanPacket.Planer.Password)
                                    {

                                        SendingInvalidLogain(SocketClient);
                                        ReConnectStatus = false;
                                    }
                                    else
                                    {
                                        SendingCurrentMachines(SocketClient);
                                        SocketClient.Planner = PlanPacket.Planer;
                                    }
                                    break;
                                case PlanningActions.SendOperation:

                                    Operations.Add(new OperationBLL(SocketClient.PlanningIP, PlanPacket.Operation.Order_Number,
                                        PlanPacket.Operation.Order_Amount,
                                        PlanPacket.Machine));
                                    SendingCurrentOperation(SocketClient.PlanningIP);
                                    break;
                                case PlanningActions.DeleteOperation:
                                    Operations.RemoveAll(r => r.PlanningIP == SocketClient.PlanningIP);
                                    SendingCurrentOperation(SocketClient.PlanningIP);
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception Ex)
                        {
                            LogsBuffer.Add(Ex.ToString());
                        }
                       

                        if (ReConnectStatus)
                            SocketClient.ClinetSocket.BeginReceive(SocketClient.Buffer, 0, SocketClient.Buffer.Length, SocketFlags.None, new AsyncCallback(OnPlanningClientRecive), SocketClient);
                        else
                            PlanningSokets.RemoveAll(r => r.PlanningIP == SocketClient.PlanningIP);

                    }
                }
            }
            catch (Exception ex)
            {
                LogsBuffer.Add(ex.ToString());
            }
        }

        private void SendingCurrentOperation(string planningIP)
        {
            try
            {
                var Planning = PlanningSokets.Where(r => r.PlanningIP == planningIP);
                foreach (var item in Planning)
                {
                    var packet = new PlanPacket();
                    packet.ActionType = PlanningActions.ReciveOperationList;
                    packet.TaskOperationList = new List<OperationEntity>();
                    Operations.Where(r => r.PlanningIP == planningIP).ToList().ForEach(r => packet.TaskOperationList.Add(new OperationEntity(r))); 
                    item.ClinetSocket.Send(packet.GetByte());
                }
               
                
            }
            catch (Exception ex)
            {
                LogsBuffer.Add(ex.ToString());
            }
        }

        private void SendingInvalidLogain(PlanningSideBLL socketClient)
        {
            try
            {
                var packet = new PlanPacket();
                packet.ActionType = PlanningActions.InvalidConnection;
                socketClient.ClinetSocket.Send(packet.GetByte());

                PlanningSokets.RemoveAll(r => r.PlanningIP == socketClient.PlanningIP);

            }
            catch (Exception ex)
            {
                LogsBuffer.Add(ex.ToString());
            }
        }

        private void SendingCurrentMachines(PlanningSideBLL socketClient)
        {
            try
            {
                var packet = new PlanPacket();
                packet.ActionType = PlanningActions.MachineList;
                packet.SetMachineList( this.MachineSokets.ToList());
                socketClient.ClinetSocket.Send(packet.GetByte());

            }
            catch (Exception ex)
            {
                LogsBuffer.Add(ex.ToString());
            }
        }

        public bool StopTCPServer()
        {
            try
            {
                /// Stop Server Node
                TCPServerMachineSocket.Blocking = false;
                TCPServerMachineSocket.Close();
                TCPServerMachineSocket.Dispose();

                /// Stop Server Node
                TCPServerPlanningSocket.Blocking = false;
                TCPServerPlanningSocket.Close();
                TCPServerPlanningSocket.Dispose();

         

                /// For Each Client Close Soket
                foreach (var Client in MachineSokets)
                    try { Client.ClinetSocket.Close(); } catch (Exception Ex) { LogsBuffer.Add(Ex.Message); }

                foreach (var Client in PlanningSokets)
                    try { Client.ClinetSocket.Close(); } catch (Exception Ex) { LogsBuffer.Add(Ex.Message); }

                /// Clear Connection List
                MachineSokets.Clear();
                PlanningSokets.Clear();

                /// Clear Operation List
                Operations.Clear();

        
                return true;
            }
            catch (Exception Ex)
            {
                LogsBuffer.Add(Ex.Message);
            }
            return false;
        }

        
        #endregion 


      

    }
}
