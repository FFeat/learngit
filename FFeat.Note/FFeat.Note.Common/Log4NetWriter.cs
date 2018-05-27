using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFeat.Note.Common
{
    public class Log4NetWriter : ILogWriter
    {
        public void LogWriter(string log)
        {
            ILog LogWriter = log4net.LogManager.GetLogger("Demo");
            LogWriter.Error(log);
        }
    }
}
