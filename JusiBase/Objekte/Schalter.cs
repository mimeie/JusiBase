using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class Schalter : Objekt
    {
        public bool Status { get; set; }
        public bool ZielStatus { get; set; }
        public string ZielObjektId { get; set; }

        public Schalter(string objektId, string zielObjektId) : base(objektId)
        {
            ZielObjektId = zielObjektId;
        }

    }
}
