using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemClassLib.Models
{
    public enum MachineStatus
    {
        Busy = 0,
        Empty = 1
    }
    public class MachineEntity
    {
       
        public string Machine_Name { get; set; }
        public string MachineType { get; set; }
        public int Speed { get; set; }

        public MachineStatus Status { get; set; }

        public MachineEntity()
        {
            
        }
        public MachineEntity(string Machine_Name, string MachineType, int Speed)
        {
            this.Machine_Name = Machine_Name;
            this.MachineType = MachineType;
            this.Speed = Speed;
        }
        internal void CopyFrom(MachinePacket packet)
        {
            this.Machine_Name = packet.Machine.Machine_Name;
            this.MachineType = packet.Machine.MachineType;
            this.Speed = packet.Machine.Speed;
            this.Status = packet.Machine.Status;
        }

    }
}
