using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class LampeHelligkeitTemperatur : LampeHelligkeit
    {

        public int Temperatur
        {
            set
            {
                clusterConn.SetIOBrokerValue(ZielObjektTemperaturId, value);
                UpdateTemperatur();
            }
        }

        public int ZielTemperatur { get; set; }

        public string ZielObjektTemperaturId { get; set; }
        public string ObjektTemperaturId { get; set; }

        public LampeHelligkeitTemperatur(string objektId, string zielObjektId, string objektHelligkeitId, string zielObjektHelligkeitId, string objektTemperaturId, string zielObjektTemperaturId) : base(objektId, zielObjektId, objektHelligkeitId, zielObjektHelligkeitId)
        {
            ZielObjektTemperaturId = zielObjektTemperaturId;
            ObjektTemperaturId = objektTemperaturId;
        }

        public void UpdateTemperatur()
        {
            IOBrokerJSONGet jsonResult = clusterConn.GetIOBrokerValue(ObjektTemperaturId);
            if (jsonResult == null && jsonResult.valInt != null)
            {
                Console.WriteLine("keine Daten erhalten");
                return;
            }
            Helligkeit = jsonResult.valInt.Value;
        }
    }
}
