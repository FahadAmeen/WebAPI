using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            public void Delete(string entity)
        {
            string ee = entity.Replace('-', '/');
            var _dateTime = _context.MyLog.Where(r => r.Created.Contains(ee));
            _context.MyLog.RemoveRange(_dateTime);
            _context.SaveChanges();
        }
  

        public void SetLog(string Message)
        {
            LoggingError logging = new LoggingError();
            if (Message == null)
            {

                logging.Type = "Info";
            }
            else
            {
                logging.Type = "Error";
            }
            logging.Description = Message;
            logging.Created = DateTime.Now.ToString();
            _context.MyLog.Add(logging);
            _context.SaveChanges();
        }

        //void ILog.SetLog(string Message, string type)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
