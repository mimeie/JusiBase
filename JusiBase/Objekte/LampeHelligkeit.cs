using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class LampeHelligkeit : Schalter
    {
        public int Helligkeit { get; set; }
    
        public int ZielHelligkeit {
            set
            {                
                    clusterConn.SetIOBrokerValue(ZielObjektHelligkeitId, value);
                    UpdateHelligkeit();
                }
            }

        public string ZielObjektHelligkeitId { get; set; }
        public string ObjektHelligkeitId { get; set; }

        public LampeHelligkeit(string objektId, string zielObjektId, string objektHelligkeitId, string zielObjektHelligkeitId) : base(objektId, zielObjektId)
        {
            ObjektHelligkeitId = objektHelligkeitId;
            ZielObjektHelligkeitId = zielObjektHelligkeitId;
        }

        public void UpdateHelligkeit()
        {
            IOBrokerJSONGet jsonResult = clusterConn.GetIOBrokerValue(ObjektHelligkeitId);
            if (jsonResult == null && jsonResult.valInt != null)
            {
                Console.WriteLine("keine Daten erhalten");
                return;
            }
            Helligkeit = jsonResult.valInt.Value;
        }
    }
}
