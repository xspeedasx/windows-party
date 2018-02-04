using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsParty.Services
{
    public interface ILogService
    {
        void LogInfo(object o);
        void LogError(object o);
    }
}
