﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class Schalter : Objekt
    {
        public bool Status { get; set; }
        public bool ZielStatus {  set
            {
                clusterConn.SetIOBrokerValue(ZielObjektId, value);
                Update();
            }
        }
        public string ZielObjektId { get; set; }

        public Schalter(string objektId, string zielObjektId) : base(objektId)
        {
            ZielObjektId = zielObjektId;
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
        }
       

    }
}