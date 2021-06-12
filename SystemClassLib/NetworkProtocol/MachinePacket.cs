using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace SystemClassLib.Models
{
    public enum MachineAction
    {
        Connect,
        StartOperation,
        FinishOperation
    }
    public class MachinePacket
    {
        [DataMember]
        public MachineAction ActionType { get; set; }
        public MachineEntity Machine { get; set; }
        public OperationEntity CurrentOperation { get; set; }
        public String PlanningIP { get; set; }

        public void CopyFromMachine(MachineSocket machine)
        {
            this.Machine.Machine_Name = machine.Machine_Name;
            this.Machine.MachineType = machine.MachineType;
            this.Machine.Speed = machine.Speed;
            this.Machine.Status = machine.Status;
        }
        public bool ConnectionStatus { get; internal set; }

        public MachinePacket() {
            this.Machine = new MachineEntity();
            this.CurrentOperation = new OperationEntity();
        }
        public byte[] GetByte()
        {
            string data = JsonConvert.SerializeObject(this);
            // Convert the string data to byte data using ASCII encoding.  
            return Encoding.ASCII.GetBytes(data);
        }

        public static MachinePacket GetPacket(byte[] packet)
        {
            return JsonConvert.DeserializeObject<MachinePacket>(Encoding.ASCII.GetString(packet));
        }
    }
}
