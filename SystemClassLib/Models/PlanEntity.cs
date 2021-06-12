using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemClassLib.Models
{
    public class PlanEntity
    {
        public string PlanerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public PlanEntity()
        {

        }

        public PlanEntity(string planerName, string userName, string password)
        {
            this.PlanerName = planerName;
            this.UserName = userName;
            this.Password = password;
        }
    }
}
