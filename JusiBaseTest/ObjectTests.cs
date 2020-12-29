using Microsoft.VisualStudio.TestTools.UnitTesting;
using JusiBase;
using System;
using System.Diagnostics;

using System.Net;

using Newtonsoft.Json;

namespace JusiBaseTest
{
    [TestClass]
    public class ObjectTests
    {
        public SensorBool DebugBool;

        [TestMethod]
        public void TestObjektEvent()
        {
            try
            {
                DebugBool = new SensorBool("zigbee.0.00158d00063a6d54.occupancy");

                DebugBool.DataChange += DoDataChange;


                DebugBool.RaiseDataChange(true);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim TestObjektEvent", ex);
                //throw;
            }
        }

        [TestMethod]
        public void TestSchalterEvent()
        {
            try
            {
                DebugBool = new SensorBool("0_userdata.0.IsAnybodyHome");

                DebugBool.DataChange += DoDataChange;


                DebugBool.RaiseDataChange(true);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim TestObjektEvent", ex);
                //throw;
            }
        }

        private void DoDataChange(object sender, Objekt obj)
        {
            try
            {
                obj.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim DoDataChange", ex);
                //throw;
            }
        }
    }
}
