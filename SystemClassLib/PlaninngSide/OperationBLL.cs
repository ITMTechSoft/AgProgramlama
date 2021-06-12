using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemClassLib.Models
{
    public class OperationBLL : OperationEntity
    {
        public MachineEntity TargetMachine { get; set; }

        public string PlanningIP { get; set; }

        public OperationBLL() {
            this.TargetMachine = new MachineSocket();
        }

        public OperationBLL(string PlanningId, string Order_Number, int Order_Amount, MachineEntity machine)
        {
            this.PlanningIP = PlanningId;
            this.Order_Number = Order_Number;
            this.Order_Amount = Order_Amount;
            this.TargetMachine = machine;
        }

        internal void CopyFromPacket(MachinePacket packet)
        {
            this.Order_Number = packet.CurrentOperation.Order_Number;
            this.Order_Amount = packet.CurrentOperation.Order_Amount;
            this.TargetMachine.CopyFrom(packet);
        }
    }
}
