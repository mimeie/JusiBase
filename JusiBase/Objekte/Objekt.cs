using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase

{
    public class Objekt
    {
        public DateTime LastChange { get; set; }
        public string ObjektId { get; set; }

        public Objekt(string objektId)
        {
            ObjektId = objektId;
        }

    }
}
