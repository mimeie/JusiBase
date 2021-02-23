using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class SensorBool : Objekt
    {
        public void DebugSetStatus(bool zielwert)
        {
            clusterConn.SetIOBrokerValue(ObjektId, zielwert);
        }

        public bool Status { get; set; }

        public DateTime LastChangeTrue { get; set; }
        public DateTime LastChangeFalse { get; set; }

        public SensorBool(string objektId) : base(objektId)
        {
           
        }

        public override void Update()
        {
            IOBrokerJSONGet jsonResult = clusterConn.GetIOBrokerValue(ObjektId);
            if (jsonResult == null && jsonResult.valBool != null)
            {
                Console.WriteLine("keine Daten erhalten");
                return;
            }
            LastChange = jsonResult.LastChange;

            Status = jsonResult.valBool.Value;
            if (Status == true)
            {
                LastChangeTrue = LastChange;
            }
            else
            {
                LastChangeFalse = LastChange;
            }
            
        }
    }
}
