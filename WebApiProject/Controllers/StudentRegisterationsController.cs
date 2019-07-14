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



namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRegisterationsController : ControllerBase
    {
        private readonly DBContext _context;

        public StudentRegisterationsController(DBContext context)
        {
            _context = context;

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
            if (!String.IsNullOrEmpty(searchData))
            {
                if (searchWith == "Id" )
                {
                    user = user.Where(s => s.Id == Int32.Parse(searchData));
                }
                else
                {
                    user = user.Where(s => EF.Property<string>(s, searchWith).Contains(searchData));
                }
            }
            return await user.Skip(pageNo * pageSize).Take(pageSize).ToArrayAsync();
        }

        //    switch (sortData)
        //    {
        //        case "id":
        //            user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Id);
        //            break;

        //        case "name":
        //            user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Name);
        //            break;

        //        case "program":
        //            user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Program);
        //            break;

        //        case "detail":
        //            user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Detail);
        //            break;
        //        case "filename":
        //            user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Filename);
        //            break;
        //        default:
        //            break;

        //    }
        //    if (!String.IsNullOrEmpty(searchData))
        //    {

        //        searchWith = searchWith.ToLower();

        //        switch (searchWith)
        //        {
        //            case "id":
        //                user = user.Where(s => s.Id == Int32.Parse(searchData));
        //                break;

        //            case "name":
        //                user = user.Where(s => s.Name.Contains(searchData));
        //                break;


        //            case "detail":
        //                user = user.Where(s => s.Detail.Contains(searchData));
        //                break;

        //            case "program":
        //                user = user.Where(s => s.Program.Contains(searchData));
        //                break;

        //            case "filename":
        //                user = user.Where(s => s.Filename.Contains(searchData));
        //                break;

        //            default:
        //                break;
        //        }

        //    }
        //    else
        //        return null;

        //    return user.Skip(pageNo * pageSize).Take(pageSize);
        //}

        // Get: api/StudentRegisterations/id

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentRegisteration([FromRoute] int id)
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
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentRegisterationExists(id))
                {
                    return NotFound();
                }
                else
                {
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
    }
}