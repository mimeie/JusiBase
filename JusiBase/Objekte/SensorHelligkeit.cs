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
    }
}
