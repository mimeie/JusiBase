using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using System.Linq;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace JusiBase
{
    public static class DNSHelper
    {
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }
            Console.WriteLine("IP: {0}, pingbar: {1}", nameOrAddress, pingable.ToString());
            return pingable;
        }

        public static IPAddress GetIP(string fqdn)
        {
            try
            {
                Console.WriteLine("prüfe ip für fqdn {0}, lokaler Host: {1}", fqdn, System.Environment.MachineName);


                if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                {
                    Console.WriteLine("Network not available");
                    return null;
                }

               
                string localIP;
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var LocalIp in host.AddressList)
                {
                    if (LocalIp.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIP = LocalIp.ToString();
                        Console.WriteLine("lokale IP: {0}", localIP);                     
                    }
                }

                //ping prüfen ob netzwerk läuft
                if (PingHost("8.8.8.8") == false && PingHost("192.168.2.1") == false)
                {
                    Console.WriteLine("abbrechen weil ping nicht erfolgreich");
                    return null;
                }

                //dns config loggen
                string dnsServer;
                NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in adapters)
                {
                    IPInterfaceProperties adapterProperties = adapter.GetIPProperties();
                    IPAddressCollection dnsServers = adapterProperties.DnsAddresses;
                    if (dnsServers.Count > 0)
                    {
                        Console.WriteLine(adapter.Description);
                        foreach (IPAddress dns in dnsServers)
                        {
                            dnsServer = dns.ToString();
                            Console.WriteLine("DNS Servers von adapter: {0} - {1} : {2}", adapter.Name, adapter.Description, dnsServer);
                        }
                        
                    }
                }


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
