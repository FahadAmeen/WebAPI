using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.ErrorLog;
using System.Web.Http;
//using System.Web.Http.Cors;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingErrorsController : ControllerBase
    {
        private LogNLog _logg;
        private readonly DBContext _context;

        public LoggingErrorsController(DBContext context)
        {
            _context = context;
            _logg = new LogNLog(context);
        }

        // GET: api/LoggingErrors
        [HttpGet]
        public async Task<IEnumerable<LoggingError>> GetLogAsync(int pageNo = 1, string searchWith = "Id", string searchData = "", string sortData = "Id", int pageSize = 5)
        {
            pageNo = pageNo - 1;
            var user = from s in _context.MyLog select s;
            user = _context.MyLog.OrderBy(s => EF.Property<object>(s, sortData));
            string sorrt = sortData;
            try
            {
                if (!String.IsNullOrEmpty(searchData))
                {
                    if (searchWith == "Id")
                    {
                        user = user.Where(s => s.Id == Int32.Parse(searchData));
                    }
                    else
                    {
                        // string ee = entity.Replace('-', '/');
                        if (searchWith == "Created")
                        {
                            string ee = searchData.Replace('-', '/');
                            user = user.Where(s => EF.Property<string>(s, searchWith).Contains(ee));

                        }
                        else
                        {
                            user = user.Where(s => EF.Property<string>(s, searchWith).Contains(searchData));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logg.SetLog(ex.ToString());
            }

            return await user.Skip(pageNo * pageSize).Take(pageSize).ToArrayAsync();
        }

        // DELETE: api/LoggingErrors/
        [HttpDelete()]
        public string[] Delete( string entity, string type)
        {
            string ee = entity.Replace('-', '/');
            var _dateTime = _context.MyLog.Where(r => r.Created.Contains(ee) && r.Type.Contains(type));
            _context.MyLog.RemoveRange(_dateTime);
            _context.SaveChanges();
            return new string[] { "Deleted" };
        }

        private bool LoggingErrorExists(int id)
        {
            return _context.MyLog.Any(e => e.Id == id);
        }

        [Route("GetAll")]
        public int GetCount()
        {
            return _context.MyLog.Count();
        }

    }
}