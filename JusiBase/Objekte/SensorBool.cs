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
        public SourceType SourceType { get; set; }

        public SensorBool(string objektId, SourceType sourceType = SourceType.TrueFalse) : base(objektId)
        {
            SourceType = sourceType;
        }

        public override void Update()
        {
            IOBrokerJSONGet jsonResult = clusterConn.GetIOBrokerValue(ObjektId);


            if (SourceType == SourceType.TrueFalse)
            {
                if (jsonResult == null && jsonResult.valBool != null)
                {
                    Console.WriteLine("keine Daten erhalten");
                    return;
                }
                LastChange = jsonResult.LastChange;

                Status = jsonResult.valBool.Value;
            }
            else if (SourceType == SourceType.Integer)
            {
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
