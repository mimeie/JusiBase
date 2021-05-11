using System;
using System.Collections.Generic;
using System.Text;

using System.Net;
using Newtonsoft.Json;

namespace JusiBase
{
    public class IOBrokerWebConnector
    {
        private static string IOBrokerRequest = "http://";
        private static string IOBrokerHost = "jportal1.mei.local";
        private static string IOBrokerPort = "8087";

        private static string IOBrokerGetParameter = "get/";
        private static string IOBrokerSetParameter = "set/";

        private string IOBrokerGetApi()
        {
            string getApi = IOBrokerAddress() +  IOBrokerGetParameter;
            //Console.WriteLine("getAPI: {0}", getApi);
            return getApi;
        }
        private string IOBrokerSetApi()
        {
            string setApi = IOBrokerAddress() + IOBrokerSetParameter;
            Console.WriteLine("setAPI: {0}", setApi);
            return setApi;
        }
        private string IOBrokerAddress()
        {
            string address = IOBrokerRequest + IOBrokerHost + ":" + IOBrokerPort + "/";
            Console.WriteLine("IOBroker Address: {0}", address);
            return address;
        }

            public IOBrokerJSONGet GetIOBrokerValue(string objectId)
        {
            try
            {
                if (DNSHelper.GetIP(IOBrokerHost) == null)
                {
                    return null;
                }

                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONGet ioJson = new IOBrokerJSONGet();

                    string downString = IOBrokerGetApi() + System.Web.HttpUtility.UrlEncode(objectId);
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONGet>(json);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker MicroService", ex);
                throw;
            }
        }
        public IOBrokerJSONSet SetIOBrokerValue(string objectId, int zielwert)
        {
            try
            {
                if (DNSHelper.GetIP(IOBrokerHost) == null)
                {
                    return null;
                }

                string zielwertString = zielwert.ToString();
               

                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONSet ioJson = new IOBrokerJSONSet();

                    string downString = IOBrokerSetApi() + System.Web.HttpUtility.UrlEncode(objectId) + "?value=" + System.Web.HttpUtility.UrlEncode(zielwertString);
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONSet>(json);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim schreiben von IOBroker Microservice", ex);
                throw;
            }
        }

        public IOBrokerJSONSet SetIOBrokerValue(string objectId, bool zielwert)
        {
            try
            {
                if (DNSHelper.GetIP(IOBrokerHost) == null)
                {
                    return null;
                }

                string zielwertString ="false";
                if (zielwert == true)
                {
                    zielwertString = "true";
                }

                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONSet ioJson = new IOBrokerJSONSet();

                    string downString = IOBrokerSetApi() + System.Web.HttpUtility.UrlEncode(objectId) + "?value=" + System.Web.HttpUtility.UrlEncode(zielwertString);
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONSet>(json);
                    return ioJson;
                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim schreiben von IOBroker Microservice", ex);
                throw;
            }
        }
    }
}
