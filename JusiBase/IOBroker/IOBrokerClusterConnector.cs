using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using Newtonsoft.Json;

namespace JusiBase
{
    public class IOBrokerClusterConnector
    {

        private static string IOBrokerRequest = "http://";
        private static string IOBrokerGetHost = "iobrokerdatacollector.prod.j1";
        private static string IOBrokerSetHost = "iobrokerdatawriter.prod.j1";

        private static string IOBrokerParameter = "api/iobroker/";


        private string IOBrokerGetApi()
        {
            string getApi = IOBrokerRequest + IOBrokerGetHost + "/" + IOBrokerParameter;
            Console.WriteLine("getAPI: {0}", getApi);
            return getApi;
        }
        private string IOBrokerSetApi()
        {
            string setApi = IOBrokerRequest + IOBrokerSetHost + "/" + IOBrokerParameter;
            Console.WriteLine("setAPI: {0}", setApi);
            return setApi;
        }      

        public IOBrokerJSONGet GetIOBrokerValue(string objectId)
        {
            try
            {
                if (DNSHelper.GetIP(IOBrokerGetHost) == null)
                {
                    return null;
                }

                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONGet ioJson = new IOBrokerJSONGet();

                    string downString = IOBrokerGetApi() + objectId;
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONGet>(json);
                    Console.WriteLine("result value {0}", ioJson.val);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                throw;
            }
        }

        public IOBrokerJSONSet SetIOBrokerValue(string objectId, int zielwert)
        {
            try
            {
                if (DNSHelper.GetIP(IOBrokerSetHost) == null)
                {
                    return null;
                }

                string zielwertString = zielwert.ToString();
                
                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONSet ioJson = new IOBrokerJSONSet();

                    string downString = IOBrokerSetApi() + objectId + "?zielwert=" + zielwertString;
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONSet>(json);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim schreiben von IOBroker", ex);
                throw;
            }
        }

        public IOBrokerJSONSet SetIOBrokerValue(string objectId, bool zielwert)
        {
            try
            {
                if (DNSHelper.GetIP(IOBrokerSetHost) == null)
                {
                    return null;
                }

                string zielwertString = "false";
                if (zielwert == true)
                {
                    zielwertString = "true";
                }

                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONSet ioJson = new IOBrokerJSONSet();

                    string downString = IOBrokerSetApi() + objectId + "?zielwert=" + zielwertString;
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONSet>(json);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim schreiben von IOBroker", ex);
                throw;
            }
        }
    }
}
