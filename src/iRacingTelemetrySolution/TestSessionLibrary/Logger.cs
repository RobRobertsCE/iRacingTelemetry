using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System.Linq;

namespace TestSessionLibrary
{
    public static class Logger
    {
        public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string LogFileName
        {
            get
            {
                var rootAppender = ((Hierarchy)LogManager.GetRepository())
                                         .Root.Appenders.OfType<FileAppender>()
                                         .FirstOrDefault();

                string filename = rootAppender != null ? rootAppender.File : string.Empty;

                return filename;
            }
        }
    }
}
