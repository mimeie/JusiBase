
using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;





namespace JusiBaseTest
{
    public class FeuchtigkeitPollJob : IJob
    {

        public FeuchtigkeitPollJob()
        {

        }


        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("FeuchtigkeitPollJob Job, startup");
            try
            {
                
                Console.WriteLine("FeuchtigkeitPollJob Job, abgeschlossen");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler im Job {0}: {1}", context.JobDetail.Key,ex);
              
            }
        }
    }
}
