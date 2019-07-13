using System;
using System.Collections.Generic;
using System.Linq;
using WebApiProject.Data;


namespace WebApiProject.ErrorLog
{
    public class LogNLog:ILog
    {

        private DBContext _context;
        public LogNLog(DBContext context)
        {
            _context = context;
        }
        public List<LoggingError> GetLog()
        {
            return _context.MyLog.ToList();
        }
        public void Delete(string entity, string type)
        {
            string ee = entity.Replace('-', '/');
           // bool b = _context.MyLog.Where(r => r.Created.Contains(ee)) && _context.MyLog.Where(r => r.Type.Contains(type));
         
           var _dateTime = _context.MyLog.Where(r => r.Created.Contains(ee) && r.Type.Contains(type) );     
           _context.MyLog.RemoveRange(_dateTime);
           _context.SaveChanges();  
        }
        
        public void SetLog(string Message)
        {
            LoggingError logging = new LoggingError
            {
                Type = "Error",
                Description = Message,
                Created = DateTime.Now.ToString()
            };
            _context.MyLog.Add(logging);
            _context.SaveChanges();
        }
        public void InfoLog(string Message)
        {
            LoggingError logging = new LoggingError
            {
                Type = "Info",
                Description = Message,
                Created = DateTime.Now.ToString()
            };
            _context.MyLog.Add(logging);
            _context.SaveChanges();
        }
        public void WarnLog(string Message)
        {
            LoggingError logging = new LoggingError
            {
                Type = "Warn",
                Description = Message,
                Created = DateTime.Now.ToString()
            };
            _context.MyLog.Add(logging);
            _context.SaveChanges();
        }
    }
}
