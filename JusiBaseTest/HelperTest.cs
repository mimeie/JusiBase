using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using JusiBase;

using System.Net;

namespace JusiBaseTest
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void TestGetIP()
        {
            try
            {
                string result;
                result = DNSHelper.GetIP("google.ch").ToString();
                result = DNSHelper.GetIP("asdsds.asdjuioiuo.ioiode").ToString();
                result = DNSHelper.GetIP("steuerungentfeuchter.prod.j1").ToString();
                result = DNSHelper.GetIP("iobrokerdatacollector.prod.j1").ToString();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Testen der IP", ex);                
                //throw;
            }
            
        }
    }
}
