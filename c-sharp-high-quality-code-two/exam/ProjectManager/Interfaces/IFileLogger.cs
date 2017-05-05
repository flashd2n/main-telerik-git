using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Interfaces
{
    public interface IFileLogger
    {
        void LogInfo(object msg);

        void LogError(object msg);

        void LogFatal(object msg);
    }
}
