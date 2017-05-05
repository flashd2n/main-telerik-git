using log4net;
using ProjectManager.Interfaces;

namespace ProjectManager.Common
{
    public class FileLogger : IFileLogger
    {
        private static ILog log;

        static FileLogger()
        {
            log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void LogInfo(object msg)
        {
            log.Info(msg);
        }   
             
        public void LogError(object msg)
        {
            log.Error(msg);
        } 
               
        public void LogFatal(object msg)
        {
            log.Fatal(msg);
        }
    }
}
