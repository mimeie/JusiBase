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
                Layout = "${message}",
                IncludeAllProperties = true,
            };
            JusiBase.LoggingBase logging = new LoggingBase(logelasticlogelastic, NLog.LogLevel.Debug, NLog.LogLevel.Fatal);
        }

        [TestMethod]
        public void TestLogger()
        {
            try
            {
               
                logger.Info("JusiBase-Test");
                throw new NullReferenceException("test ist null");
            }

            catch (Exception ex)
            {
                logger.Error("Fehler beim Testen des Loggen", ex);
                //throw;
            }

        }
    }
}
