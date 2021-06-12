using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemClassLib.Models
{
    public enum PlanningActions
    {
        FirstConnect =1,
        SendOperation =2,
        DeleteOperation =3,
        ReciveOperationList =4,
        MachineList =5,
        ConnectionStatus = 6,
        InvalidConnection = 7
    }
    public class PlanPacket
    {
        public PlanEntity Planer { get; set; }
        public OperationEntity Operation { get; set; }
        public MachineEntity Machine { get; set; }
        public List<OperationEntity> TaskOperationList { get; set; }
        public List<MachineEntity> MachineTypeList { get; set; }

        public PlanningActions ActionType { get; set; }
        public bool? ConnectionStatus { get; internal set; }

        public PlanPacket()
        {
            this.Planer = new PlanEntity();
            this.Operation = new OperationEntity();
            this.Machine = new MachineEntity();
            this.TaskOperationList = new List<OperationEntity>();
            this.MachineTypeList = new List<MachineEntity>();
        }

        public byte[] GetByte()
        {
            string data = JsonConvert.SerializeObject(this);
            // Convert the string data to byte data using ASCII encoding.  
            return Encoding.ASCII.GetBytes(data);
        }

        public static PlanPacket GetPacket(byte[] packet)
        {
            try
            {
                string Data = Encoding.ASCII.GetString(packet);
                return JsonConvert.DeserializeObject<PlanPacket>(Data);
            }
            catch (Exception ex)
            {
                return new PlanPacket();
            }
          
        }

        internal void SetMachineList(List<MachineSocket> machineBLLs)
        {
            var MachineTypes = machineBLLs.Select(r => new { r.MachineType, r.Speed }).ToList().Distinct().ToList();
            this.MachineTypeList = new List<MachineEntity>();
            MachineTypes.ForEach(r => this.MachineTypeList.Add(new MachineEntity("", r.MachineType, r.Speed)));
        }
    }
}
