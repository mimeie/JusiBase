using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class ResponseBase
    {
        public DateTime Date
        {
            get
            {
                return DateTime.Now;
            }
        }

        public string Host
        {
            get
            {
                return System.Environment.MachineName;
            }
        }
    }
}
