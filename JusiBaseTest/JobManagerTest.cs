using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using JusiBase;

namespace JusiBaseTest
{
    [TestClass]
    public class JobManagerTest
    {
        private JobManager _jobManager;

        [TestMethod]
        public void TestJobManager()
        {
            try
            {
                _jobManager = new JobManager();
                _jobManager.Initialize();

                //InitializeFeuchtigkeitPollJob();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Testen des job managers", ex);
                //throw;
            }

        }


        //private void InitializeFeuchtigkeitPollJob()
        //{
        //    IJobDetail feuchtigkeitPollJob = JobBuilder.Create<FeuchtigkeitPollJob>()
        //        .WithIdentity("FeuchtigkeitPollJob")
        //        .Build();

        //    // Trigger the job to run now, and then repeat every x seconds
        //    ITrigger feuchtigkeitPollTrigger = TriggerBuilder.Create()
        //        .WithIdentity("FeuchtigkeitPollJobTrigger")
        //        .StartNow()
        //        .WithSimpleSchedule(x => x
        //            .WithIntervalInMinutes(10)
        //            .RepeatForever())
        //        .Build();

        //    _scheduler.ScheduleJob(feuchtigkeitPollJob, feuchtigkeitPollTrigger);
        //    Console.WriteLine("FeuchtigkeitPollJob mit Interval {0}min gestartet", 11);
        //}
    }
}
