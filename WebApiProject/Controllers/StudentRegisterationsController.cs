using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration.Ini;
using System.Net;
using WebApiProject.ErrorLog;
using Microsoft.Extensions.Logging;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegisterationsController : ControllerBase
    {
        private ILogger logger;
        private LogNLog _logg;
        private readonly DBContext _context;

        public StudentRegisterationsController(DBContext context)
        {
            _context = context;
            _logg = new LogNLog(context);

        }
        [Route( "GetAll")]
        public int GetCount()
        {
            return _context.StudentRegisterations.Count();
       
        }


        // GET: api/StudentRegisterations
        [HttpGet]
        public async Task<IEnumerable<StudentRegisteration>> GetStudentRegisterationsAsync(int pageNo = 1, string searchWith = "Id", string searchData = "", string sortData = "Id", int pageSize = 5)
        {

            pageNo = pageNo - 1;
            var user = from s in _context.StudentRegisterations select s;
            user = _context.StudentRegisterations.OrderBy(s=>EF.Property<object>(s, sortData));
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
                        user = user.Where(s => EF.Property<string>(s, searchWith).Contains(searchData));
                    }
                }
            }
            catch (Exception ex)
            {
                _logg.SetLog(ex.ToString());
            }

            return await user.Skip(pageNo * pageSize).Take(pageSize).ToArrayAsync();
        }
        
        // Get: api/StudentRegisterations/id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentRegisteration([FromRoute] int id)
        {
           
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                 var studentRegisteration = await _context.StudentRegisterations.FindAsync(id);

                if (studentRegisteration == null)
                {
                    return NotFound();
                }
                return Ok(studentRegisteration);
            }
            catch(Exception ex)
            {
               // _logg.SetLog(ex.ToString());
            }
            return NotFound();
        }

        // PUT: api/StudentRegisterations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentRegisteration([FromRoute] int id, [FromBody] StudentRegisteration studentRegisteration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentRegisteration.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentRegisteration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!StudentRegisterationExists(id))
                {
                  //logger.LogError(ex.ToString());
                    _logg.SetLog(ex.ToString());
                    return NotFound();
                   

                }
                else
                {
                    _logg.SetLog(ex.ToString());
                    return NoContent();
                   
                }
                
            }

            return NoContent();
        }

        // POST: api/StudentRegisterations
        [HttpPost]
        public async Task<IActionResult> PostStudentRegisteration([FromBody] StudentRegisteration studentRegisteration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.StudentRegisterations.Add(studentRegisteration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentRegisteration", new { id = studentRegisteration.Id }, studentRegisteration);
        }

        // DELETE: api/StudentRegisterations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentRegisteration([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studentRegisteration = await _context.StudentRegisterations.FindAsync(id);
            if (studentRegisteration == null)
            {
                return NotFound();
            }

            _context.StudentRegisterations.Remove(studentRegisteration);
            await _context.SaveChangesAsync();

            return Ok(studentRegisteration);
        }

        private bool StudentRegisterationExists(int id)
        {
            return _context.StudentRegisterations.Any(e => e.Id == id);
        }
        [HttpDelete("dellog/{datetime}")]
        public ActionResult<IEnumerable<string>> Delete(string datetime , string type)
        { //Must give the date format in dd-mm-yy time am or pm

            _logg.Delete(datetime, type);
            return new string[] { "Deleted" };
        }
        [HttpGet("Getlog")]
        public List<LoggingError> Get()
        {
            return _logg.GetLog();
        }
        [HttpGet("Try")]
        public ActionResult<IEnumerable<string>> DividedByZero()
        {
            try
            {
                int a = 2, b = 0, c;
                c = a / b;
            }
            catch (DivideByZeroException ex)
            {
                logger.LogError(ex.ToString());
                // _logg.SetLog(ex.ToString());

            }

            return new string[] { "value3", "value5" };
        }

    }
}