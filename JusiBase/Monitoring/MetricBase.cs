using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace JusiBase
{
    public class MetricBase
    {
        public Stopwatch stopwatch;

        public MetricBase()
        {
            stopwatch = new Stopwatch();
        }
    }
}
