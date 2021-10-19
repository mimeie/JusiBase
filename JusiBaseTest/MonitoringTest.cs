using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using JusiBase;

using System.Net;

using NLog;
using NLog.Targets.ElasticSearch;

namespace JusiBaseTest
{
    [TestClass]
    public class MonitoringTest
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MonitoringTest()
        {
            ElasticSearchTarget logelasticlogelastic = new ElasticSearchTarget
            {
                Name = "elastic",
                Uri = "http://jhistorian.prod.j1:9200/",  //Uri = "http://192.168.2.41:32120", 
                Index = "JusiBase-${level}-${date:format=yyyy-MM-dd}",
                //Index = "historianWriter-${level}-${date:format=yyyy-MM-dd}",
                //Layout = "${logger} | ${threadid} | ${message}",
                Layout = "${longdate}|${event-properties:item=EventId_Id}|${uppercase:${level}}|${logger}|${message} ${exception:format=tostring}|url: ${aspnet-request-url}|action: ${aspnet-mvc-action}",
                IncludeAllProperties = true,
            };
            JusiBase.LoggingBase logging = new LoggingBase(logelasticlogelastic, NLog.LogLevel.Debug, NLog.LogLevel.Fatal);
        }

        [TestMethod]
        public void TestLogger()
        {
            try
            {
               
                logger.WithProperty("Prozess", logger.Name).Info("JusiBase-Test");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Testen des Loggen", ex);
                //throw;
            }

        }
    }
}
