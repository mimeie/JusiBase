using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class SensorHelligkeit : Objekt
    {
        public void DebugSetHelligkeit(int zielwert)
        {
            clusterConn.SetIOBrokerValue(ObjektId, zielwert);
        }

        public int Helligkeit { get; set; }

        public int Abschaltlevel { get; set; }

        public SensorHelligkeit(string objektId, int _abschaltlevel) : base(objektId)
        {
            Abschaltlevel = _abschaltlevel;
        }

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
            LastChange = jsonResult.LastChange;
        }
    }
}
