using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemClassLib.Models
{
    public class OperationEntity
    {
        public bool IsStarted { get; set; }
        public string Order_Number { get; set; }
        public int Order_Amount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public OperationEntity()
        {

        }
        public OperationEntity(string Order_Number, int Order_Amount)
        {
            this.Order_Number = Order_Number;
            this.Order_Amount = Order_Amount;
        }

        public OperationEntity(OperationBLL oper)
        {
            this.Order_Number = oper.Order_Number;
            this.Order_Amount = oper.Order_Amount;
            this.StartTime = oper.StartTime;
            this.EndTime = oper.EndTime;
        }

        public override string ToString() {
            string Status = "Pending";
            if (StartTime != DateTime.MinValue && EndTime == DateTime.MinValue)
                Status = "Started";
            else 
            if (StartTime != DateTime.MinValue && EndTime != DateTime.MinValue)
                Status = "Finished";
            return string.Format("Order: {0}, Status : {1}", this.Order_Number, Status);


        }
    }
}
