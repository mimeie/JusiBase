using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase
{
    public class IOBrokerJSONGet
    {
        public string val { get; set; }
        public string ack { get; set; }
        public string from { get; set; }
        public string type { get; set; }
        public long ts { get; set; }
        public long lc { get; set; }



        public DateTime LastChange
        {
            get { return IOBrokerConverter.JavaTimeStampToDateTime(lc); }
        }
        public DateTime TimeStamp
        {
            get { return IOBrokerConverter.JavaTimeStampToDateTime(ts); }
        }

        public string valString
        {
            get { return val; }
        }

        public int? valInt
        {
            get 
            {
                try
                {
                    return Convert.ToInt32(val);
                }
                catch (Exception ex)
                {
                    return null;
                    //throw;
                }
            }            
        }

        public double? valDouble
        {            
            get
            {
                try
                {
                    return Convert.ToDouble(val);
                }
                catch (Exception ex)
                {
                    return null;
                    //throw;
                }
            }
        }

        public bool? valBool
        {           
            get
            {
                try
                {
                    if (val == "true")
                    {
                        return true;
                    }
                    else if (val == "false")
                    {
                        return false;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                    //throw;
                }
            }
        }
    }
}
