using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class Multisensor
    {
        public SensorBool Bewegung { get; set; }

        public SensorFeuchtigkeit Feuchtigkeit { get; set; }
        public SensorHelligkeit Helligkeit { get; set; }
    }
}
