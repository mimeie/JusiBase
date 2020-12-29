using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase

{
    public abstract class Objekt 
    {
        public event EventHandler<Objekt> DataChange;

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
