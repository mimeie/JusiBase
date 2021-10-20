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
        public IOBrokerJSONCommon common { get; set; }




        public DateTime LastChange
        {
            get {
                try
                {
                    return IOBrokerConverter.JavaTimeStampToDateTime(lc);
                }
                catch (Exception ex)
                {
                    return DateTime.MinValue;
                    //throw;
                }
                 
            }
        }
        public DateTime TimeStamp
        {
            get {
                try
                {
                    return IOBrokerConverter.JavaTimeStampToDateTime(ts);
                }
                catch (Exception ex)
                {
                    return DateTime.MinValue;
                    //throw;
                }
                 }
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
