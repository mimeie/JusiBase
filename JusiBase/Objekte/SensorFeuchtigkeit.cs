using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class SensorFeuchtigkeit : Objekt
    {
        public int Feuchtigkeit { get; set; }
        public int Abschaltlevel { get; set; }
        public int LimitHigh { get; set; }
        public int LimitHighDelayHours { get; set; }
        public DateTime LimitHighTime { get; set; }

        public SensorFeuchtigkeit(string objektId, int _limitHigh, int _limitHighDelayHours, int _abschaltlevel) : base(objektId)
        {
            LimitHigh = _limitHigh;
            LimitHighDelayHours = _limitHighDelayHours;
            Abschaltlevel = _abschaltlevel;
        }
        public int CheckIntervallMinutes
        {
            get
            {
                return 60;
            }
        }

        public override void Update()
        {
            IOBrokerJSONGet jsonResult = clusterConn.GetIOBrokerValue(ObjektId);
            if (jsonResult == null && jsonResult.valInt != null)
            {
                Console.WriteLine("keine Daten erhalten");
                return;
            }
            Feuchtigkeit = jsonResult.valInt.Value;
            LastChange = jsonResult.LastChange;
        }

    }
}
