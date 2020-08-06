using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public static class IOBrokerConverter
    {
        public static DateTime JavaTimeStampToDateTime(long javaTimeStamp)
        {
            // Java timestamp is milliseconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddMilliseconds(javaTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
