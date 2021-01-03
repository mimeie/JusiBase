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
        public Schalter SchalterBool;

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
                SchalterBool = new Schalter("shelly.0.SHSW-25#D8BFC01A2B2A#1.Relay0.Switch");
                SchalterBool.Update();
                SchalterBool.MinLaufzeitMinutes = 1;

                double restlaufzeit = SchalterBool.RestlaufzeitMinutes;



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
