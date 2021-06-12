using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemClassLib.Models
{
   
    public class MachineSocket : MachineEntity
    {
        #region Program Paramter
        public OperationEntity CurrentOperation { get; set; }

        public int OperationCounter { get; set; }

        public string PlanningIP { get; set; }
        #endregion

        #region Socket Parameters

        public Socket ClinetSocket = null;
        public DateTime LastConnectionTime { get; set; }
        public byte[] Buffer = new byte[8192];
        public string MachineIP { get; set; }
        public string ServerIP { get; set; }
        public string ServerPort { get; set; }
        public List<string> LogMessage { get; set; }
        public bool ConnectionStatus { get; set; }
        
        public Task OperationTask { get; set; }
        public bool OperationStatus { get; set; }

        #endregion
         

    

        public MachineSocket() {
            CurrentOperation = new OperationEntity();

        }

        public MachineSocket(Socket clinetSocket, int IntervalTime = 4000)
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

        public MachineSocket(string ServerIP, string ServerPort, string Machine_Name, string MachineType, int Speed)
        {
            this.ServerIP = ServerIP;
            this.ServerPort = ServerPort;
            this.Machine_Name = Machine_Name;
            this.MachineType = MachineType;
            this.Speed = Speed;
            this.LogMessage = new List<string>();
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
                this.Status = MachineStatus.Empty;
                return true;
            }
            catch (Exception e)
            {
                LogMessage.Add(e.ToString());
            }
            return false;
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                var ClientConnect = (MachineSocket)ar.AsyncState;

                // Complete the connection.  
                ClientConnect.ClinetSocket.EndConnect(ar);

                if (ClientConnect.ClinetSocket != null && ClientConnect.ClinetSocket.RemoteEndPoint != null)
                    ClientConnect.MachineIP = ClientConnect.ClinetSocket.RemoteEndPoint.ToString();

                ClientConnect.ClinetSocket.BeginReceive(this.Buffer, 0, ClientConnect.Buffer.Length, SocketFlags.None, new AsyncCallback(OnClinetRecive), ClientConnect);
            }
            catch (Exception e)
            {
                LogMessage.Add(e.ToString());
            }
        }

        public void SendMachineStatus(MachineAction AType)
        {
            try
            {
                var Packet = new MachinePacket();
                Packet.CopyFromMachine(this);
                Packet.ActionType = AType;
                Packet.PlanningIP = this.PlanningIP;
                this.ClinetSocket.Send(Packet.GetByte());
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
                                SocketClient.ConnectionStatus = Packet.ConnectionStatus;
                                break;
                            case MachineAction.StartOperation:
                                SocketClient.CurrentOperation = Packet.CurrentOperation;
                                SocketClient.PlanningIP = Packet.PlanningIP;
                                SocketClient.StartWorkingTime();
                              
                                break;
                            case MachineAction.FinishOperation:
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

        public void StartWorkingTime()
        {
            this.CurrentOperation.StartTime = DateTime.Now;
            this.Status = MachineStatus.Busy;
            SendMachineStatus(MachineAction.StartOperation);
            this.OperationStatus = true;
            OperationTask = Task.Factory.StartNew(() => { OperationTimerWork(); });
        }

        public void OperationTimerWork()
        {
            OperationCounter = 0;
            do
            {
                OperationCounter++;
                Thread.Sleep(this.Speed * 1000);
            } while (OperationCounter < this.CurrentOperation.Order_Amount);

            this.Status = MachineStatus.Empty;
            this.CurrentOperation.EndTime = DateTime.Now;
            SendMachineStatus(MachineAction.FinishOperation);
        }


        public void SendAction(MachinePacket MachinePacket)
        {
            try
            {
                if (this.ClinetSocket.Blocking)
                {
                    // Begin sending the data to the remote device.  
                    this.ClinetSocket.Send(MachinePacket.GetByte());
                }
            }
            catch (Exception Ex)
            {
                LogMessage.Add(Ex.ToString());
            }

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
    }
}
