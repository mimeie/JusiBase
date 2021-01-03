using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class SensorBool : Objekt
    {
        public bool Status { get; set; }

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
            Status = jsonResult.valBool.Value;
            LastChange = jsonResult.LastChange;
        }
    }
}
