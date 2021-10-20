using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NLog;
using NLog.Targets.ElasticSearch;

namespace JusiBase
{
    public class LoggingBase
    {
        public static Logger loggerBase;

        //probeweise loggen
        private NLog.Config.LoggingConfiguration config;
        private ElasticSearchTarget logelastic;


        public LoggingBase(ElasticSearchTarget elastictarget, NLog.LogLevel logLevelMin,  NLog.LogLevel logLevelMax)
        {
            // Rules for mapping loggers to targets
            //config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logelastic);

            //// Apply config
            //NLog.LogManager.Configuration = config;
            //logger = NLog.LogManager.GetCurrentClassLogger();

            

            config = new NLog.Config.LoggingConfiguration();
            logelastic = elastictarget;

            //Standardfelder hinzufügen
            logelastic.Fields.Add(new Field() { Name = "Logger", Layout = "${logger}" });
            logelastic.Fields.Add(new Field() { Name = "Host", Layout = "${hostname}" });
            logelastic.Fields.Add(new Field() { Name = "CallSite", Layout = "${callsite:className=true:filename=false:includeNamespace=false}" });
            logelastic.Fields.Add(new Field() { Name = "ThreadId", Layout = "${threadid}" });
            logelastic.Fields.Add(new Field() { Name = "Exception", Layout = "${exception}" });
            logelastic.Fields.Add(new Field() { Name = "StackTrace", Layout = "${stacktrace}" });
       

            // Rules for mapping loggers to targets
            config.AddRule(logLevelMin, logLevelMax, logelastic);

            // Apply config
            NLog.LogManager.Configuration = config;
            loggerBase = NLog.LogManager.GetCurrentClassLogger();


            loggerBase.WithProperty("Prozess", loggerBase.Name).Info($"LoggingBase Klasse initialisiert");
        }
    }
}
