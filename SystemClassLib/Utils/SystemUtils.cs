using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SystemClassLib.Utils
{
    public class SystemUtils
    {
        public static List<string> GetSystemPorts()
        {
            List<string> ServerIps = new List<string>();
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIps.Add(ip.ToString());
                }
            }
            return ServerIps;
        }
    }
}
