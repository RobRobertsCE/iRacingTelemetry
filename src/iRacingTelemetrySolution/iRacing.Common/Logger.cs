using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;
using System.Linq;

namespace iRacing
{
    public static class Logger
    {
        public static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
