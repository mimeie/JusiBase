using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using Newtonsoft.Json;

namespace JusiBase
{
    public class IOBrokerClusterConnector
    {
        private static string IOBrokerGetApi = "http://iobrokerdatacollector.prod-system.192.168.2.114.xip.io/api/iobroker/";
        private static string IOBrokerSetApi = "http://iobrokerdatawriter.prod-system.192.168.2.114.xip.io/api/IoBroker/";

        public IOBrokerJSONGet GetIOBrokerValue(string objectId)
        {
            try
            {
                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONGet ioJson = new IOBrokerJSONGet();

                    string downString = IOBrokerGetApi + objectId;
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONGet>(json);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                throw;
            }
        }

        public IOBrokerJSONSet SetIOBrokerValue(string objectId, bool zielwert)
        {
            try
            {
                string zielwertString = "false";
                if (zielwert == true)
                {
                    zielwertString = "true";
                }

                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONSet ioJson = new IOBrokerJSONSet();

                    string downString = IOBrokerSetApi + objectId + "?zielwert=" + zielwertString;
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONSet>(json);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                throw;
            }
        }
    }
}
