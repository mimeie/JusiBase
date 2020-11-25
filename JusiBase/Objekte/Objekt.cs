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


        //data change könnte man mal angehen

        //public event EventHandler<string> DataChange;
        //public void RaiseDataChange(string source)
        ////protected virtual void OnProcessCompleted(SensorBool sensorBool)
        //{
        //    DataChange?.Invoke(this, source);
        //}



    }
}
