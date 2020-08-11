using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Linq;
using System.Net.Sockets;

namespace JusiBase
{
    public static class DNSHelper
    {
        public static IPAddress GetIP(string fqdn)
        {
            try
            {
                Console.WriteLine("prüfe ip für fqdn {0}", fqdn);
                IPAddress ip = Dns.GetHostAddresses(fqdn).FirstOrDefault();
                Console.WriteLine("ip resultat {0}", ip.ToString());
                return ip;

            }

            catch (SocketException ex)
            {
                //if (ex.)
                Console.WriteLine("SocketException, Host nicht erreichbar", ex);
                return null;
                //throw;
            }
            catch (Exception ex)
            {
                //if (ex.)
                Console.WriteLine("Allgemeiner Fehler beim Testen der IP", ex);                
                throw;
            }
        }
    }
}
