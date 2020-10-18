using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class SensorHelligkeit : Objekt
    {
        public int Helligkeit { get; set; }

        public SensorHelligkeit(string objektId) : base(objektId)
        {

        }

        public override void Update()
        {
            IOBrokerJSONGet jsonResult = clusterConn.GetIOBrokerValue(ObjektId);
            if (jsonResult == null && jsonResult.valInt != null)
            {
                Console.WriteLine("keine Daten erhalten");
                return;
            }
            Helligkeit = jsonResult.valInt.Value;
        }
    }
}
