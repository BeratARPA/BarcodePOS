using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    public class GetIPv4Address
    {
        public static string Get()
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in ipEntry.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "localhost";
        }
    }
}
