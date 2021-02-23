using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase

{
    public abstract class Objekt 
    {
        public event EventHandler<Objekt> DataChange;

        

        public double MinLaufzeitMinutes { get; set; }

        public double RestlaufzeitMinutes(DateTime reference)
        {             
                if (reference != null && MinLaufzeitMinutes != 0)
                {
                    DateTime endDate = reference.AddMinutes(MinLaufzeitMinutes);
                    DateTime dtNow = DateTime.Now;
                    if (endDate <= dtNow)
                    {
                        return 0;
                    }
                    else
                    {
                        return (endDate - dtNow).TotalMinutes + 0.02; //etwas verlängern damit es nicht knapp reicht
                    }
                }
                else
                {
                    return 0;
                }            
        }

        public bool HasRestlaufzeit(DateTime reference)
        {            
                if (RestlaufzeitMinutes(reference) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            
        }

        public DateTime LastChange { get; set; }
        public string ObjektId { get; set; }

        public IOBrokerClusterConnector clusterConn;

        public Objekt(string objektId)
        {
            clusterConn = new IOBrokerClusterConnector();
            ObjektId = objektId;
            
        }

        public abstract void Update();


        public void RaiseDataChange(bool WithUpdate)       
        {
            //DataChange?.Invoke(this, null);
            if (WithUpdate == true)
            {
                Update();
            }
            DataChange?.Invoke(this, this);
        }



    }
}
