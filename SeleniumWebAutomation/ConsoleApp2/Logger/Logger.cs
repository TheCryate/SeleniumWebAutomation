using log4net;
using OpenQA.Selenium;
using SeleniumWebOtomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.MyLogger
{
   public static class MyLog
    {
        static ILog log = log4net.LogManager.GetLogger(typeof(Program));

        

        static MyLog()
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.config"));

        }
        public static void Log(string message)
        {
            log.Debug(message);
        }
        public static void printItemDetails(IWebElement element)
        {

            //Print all the details of the item as IWebElement
          
            
           log.Debug("InnerText: "+ element.GetDomProperty("innerHTML")+"\n");


            
            

        }

        public static void Log(string message, int level)
        {
            switch (level)
            {
                case LoggerCons.DEBUG:
                    log.Debug(message);
                    break;
                case LoggerCons.INFO:
                    log.Info(message);
                    break;
                case LoggerCons.WARN:
                    log.Warn(message);
                    break;
                case LoggerCons.ERROR:
                    log.Error(message);
                    break;
                case LoggerCons.FATAL:
                    log.Fatal(message);
                    break;
            }
            
        }
        
        
    }
}
