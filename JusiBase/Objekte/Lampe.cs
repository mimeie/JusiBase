using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class Lampe : Schalter
    {
        public int Helligkeit { get; set; }
        public int Temperatur { get; set; }

        public int ZielHelligkeit { get; set; }
        public int ZielTemperatur { get; set; }

        public Lampe(string objektId, string zielObjektId) : base(objektId, zielObjektId)
        {
            
        }
    }
}
