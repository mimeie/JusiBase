using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase

{
    public abstract class Objekt 
    {
        public event EventHandler<Objekt> DataChange;


        public double MinLaufzeitMinutes { get; set; }

        public double RestlaufzeitMinutes
        { //prüfen ob das wirklich der richtige ort ist, sollte allenfalls der sensor sein(bezeichnung dann richtig?)
            get
            {
                if (LastChange != null && MinLaufzeitMinutes != 0)
                {
                    DateTime endDate = LastChange.AddMinutes(MinLaufzeitMinutes);
                    DateTime dtNow = DateTime.Now;
                    if (endDate <= dtNow)
                    {
                        return 0;
                    }
                    else
                    {
                        return (endDate - dtNow).TotalMinutes;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }

        public bool HasRestlaufzeit
        {
            get
            {
                if (RestlaufzeitMinutes > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
