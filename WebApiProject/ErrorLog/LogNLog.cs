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
            if (!_context.MyLog.Any())
            {
               //      Console.WriteLine("No Content Available in the Table");
                return _context.MyLog.ToList();

            }
            return _context.MyLog.ToList();
        }
        public string[] Delete(string entity, string type)
        { 
                string ee = entity.Replace('-', '/');
                var _dateTime = _context.MyLog.Where(r => r.Created.Contains(ee) && r.Type.Contains(type));
                _context.MyLog.RemoveRange(_dateTime);
                _context.SaveChanges();
                return new string[] { "Deleted" };
           

        }
      public bool DataExists(string entity, string type)
        {
            string ee = entity.Replace('-', '/');
            return _context.MyLog.Any(r => r.Created.Contains(ee) && r.Type.Contains(type));
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
        public void InfoLog(string Message,int info)
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
        public void WarnLog(object info)
        {
            LoggingError logging = new LoggingError();

            logging.Type = "Warn";
            logging.Created = DateTime.Now.ToString();
            logging.Description = "Not Found  " + info;
                       
            _context.MyLog.Add(logging);
            _context.SaveChanges();
        }
        string ILog.Delete(string entity, string type)
        {
            throw new NotImplementedException();
        }
    }
}
