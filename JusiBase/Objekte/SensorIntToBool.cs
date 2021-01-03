using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class SensorIntToBool : SensorBool
    {
        public SensorIntToBool(string objektId) : base(objektId)
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
            if (jsonResult.valInt.Value == 255)
            {
                Status = true;
            }
            else
            {
                Status = false;
            }
            LastChange = jsonResult.LastChange;
        }
    }
}
