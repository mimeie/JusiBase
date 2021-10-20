using Microsoft.VisualStudio.TestTools.UnitTesting;
using JusiBase;
using System;
using System.Diagnostics;

using System.Net;

using Newtonsoft.Json;

namespace JusiBaseTest
{
    [TestClass]
    public class APITests
    {
        public static string IOBrokerApi = "http://jportal1:8087/get/";

        [TestMethod]
        public void TestPushMessage()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    

                    string messengerAdress = "http://messenger.prod.j1/api/messenger/push?";
                    string subject = "hallo test subject";
                    string message = "hallo wie geht es";

                    //http://messenger.prod.j1/api/messenger/test?subject=hallo&text=testmessage
                    string downString = messengerAdress + "subject=" + System.Web.HttpUtility.UrlEncode(subject) + "&text=" + System.Web.HttpUtility.UrlEncode(message);
                    Console.WriteLine("Download String '{0}'", downString);

                    var json = wc.DownloadString(downString);
                    
                }


            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim schreiben einer pushmessage", ex);
                //throw;
            }
        }

      
        private IOBrokerJSONGet getResult(string iobrokertag)
        {
            

            IOBrokerJSONGet ioJson = new IOBrokerJSONGet();
            
            IOBrokerClusterConnector wc = new IOBrokerClusterConnector();
           
            ioJson = wc.GetIOBrokerValue("zigbee.0.00158d00045c0c7c.temperature");


            
            return ioJson;
        }

        [TestMethod]
        public void TestGetValuePerformance()
        {
            try
            {
                IOBrokerJSONGet ioJson;

                Stopwatch sw = new Stopwatch();
                sw.Start();

                ioJson = getResult("zigbee.0.00158d00045c0c7c.temperature");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity"); 
                ioJson = getResult("zwave2.0.Node_003.Multilevel_Sensor.humidity");

                string temp3 = sw.ElapsedMilliseconds.ToString();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestGetValue()
        {
            try
            {
                IOBrokerJSONGet ioJson = new IOBrokerJSONGet();
                IOBrokerClusterConnector wc = new IOBrokerClusterConnector();
                ioJson= wc.GetIOBrokerValue("zwave2.0.Node_003.Basic.currentValue");
                                

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestSetValueInObject()
        {
            try
            {
                Schalter entf = new Schalter("zwave2.0.Node_031.Binary_Switch.currentValue", "zwave2.0.Node_031.Binary_Switch.targetValue");
                entf.ZielStatus = false;





            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim schreiben von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestSetValue()
        {
            try
            {
                IOBrokerJSONSet ioJson = new IOBrokerJSONSet();
                IOBrokerClusterConnector wc = new IOBrokerClusterConnector();
                ioJson = wc.SetIOBrokerValue("zwave2.0.Node_031.Binary_Switch.targetValue", true);


            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestSetSchalterValue()
        {
            try
            {
                Schalter LichtAnkleide = new Schalter("shelly.0.SHSW-25#D8BFC01A2B2A#1.Relay0.Switch");
                LichtAnkleide.ZielStatus = false;

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim setzen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestSetClusterValue()
        {
            try
            {
                IOBrokerJSONSet ioJson = new IOBrokerJSONSet();
                IOBrokerClusterConnector wc = new IOBrokerClusterConnector();
                ioJson = wc.SetIOBrokerValue("shelly.0.SHSW-25#D8BFC01A2B2A#1.Relay0.Switch", false);


            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim setzen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestSetIOBrokerValue()
        {
            try
            {
                IOBrokerJSONSet ioJson = new IOBrokerJSONSet();
                IOBrokerWebConnector wc = new IOBrokerWebConnector();
                ioJson = wc.SetIOBrokerValue("shelly.0.SHSW-25#D8BFC01A2B2A#1.Relay0.Switch",false);


            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim setzen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestGetIOBrokerValue()
        {
            try
            {
                IOBrokerJSONGet ioJson = new IOBrokerJSONGet();
                IOBrokerWebConnector wc = new IOBrokerWebConnector();
                ioJson = wc.GetIOBrokerValue("zigbee.0.00158d00045c0c7c.temperature");


            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestDoubleBool()
        {
            try
            {
                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONGet ioJson = new IOBrokerJSONGet();

                    string downString = IOBrokerApi + "zwave2.0.Node_024.Multilevel_Sensor.airTemperature";
                    Console.WriteLine("Download String '{0}'", downString);


                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONGet>(json);

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestIntBool()
        {
            try
            {
                //zwave2.0.Node_003.Multilevel_Sensor.humidity
                using (WebClient wc = new WebClient())
                {
                    IOBrokerJSONGet ioJson = new IOBrokerJSONGet();

                    string downString = IOBrokerApi + "zwave2.0.Node_024.Binary_Sensor.any";
                    Console.WriteLine("Download String '{0}'", downString);


                    var json = wc.DownloadString(downString);
                    ioJson = JsonConvert.DeserializeObject<IOBrokerJSONGet>(json);

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim lesen von IOBroker", ex);
                //throw;
            }
        }
    }
}
