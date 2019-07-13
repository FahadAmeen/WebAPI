using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.ErrorLog
{
    public interface ILog
    {
        List<LoggingError> GetLog();
        void SetLog(string Message);

        void Delete(string entity, string type);
        void InfoLog(string Message);
        void WarnLog(string Message);

    }
}
