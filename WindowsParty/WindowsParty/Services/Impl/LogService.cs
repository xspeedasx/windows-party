using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsParty.Services.Impl
{
    public class LogService : ILogService
    {
        public LogService()
        {
            if (!Directory.Exists("logs"))
                Directory.CreateDirectory("logs");
        }

        private string LogFilePath => Path.Combine("logs", "log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");

        public void LogError(object o)
        {
            File.AppendAllText(LogFilePath, $"[{DateTime.Now.ToString("s")}] ERROR: {o.ToString()}\r\n");
        }

        public void LogInfo(object o)
        {
            File.AppendAllText(LogFilePath, $"[{DateTime.Now.ToString("s")}] INFO: {o.ToString()}\r\n");
        }
    }
}
