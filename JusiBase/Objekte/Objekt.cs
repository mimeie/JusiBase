using System;
using System.Collections.Generic;
using System.Text;

namespace JusiBase

{
    public abstract class Objekt 
    {
        public DateTime LastChange { get; set; }
        public string ObjektId { get; set; }

        public IOBrokerClusterConnector clusterConn;

        public Objekt(string objektId)
        {
            clusterConn = new IOBrokerClusterConnector();

            ObjektId = objektId;
            
        }

        public abstract void Update();

        
    }
}
