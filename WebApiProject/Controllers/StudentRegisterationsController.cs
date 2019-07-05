using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

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


        //[HttpGet("GetAll")]
        //public string get(int pageNo, string searchWith, string searchData, string sortData = "", int pageSize = 5)
        //{
        //    // _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Name);
        //    pageNo = pageNo - 1;
        //    sortData = sortData.ToLower();
        //    var user = from s in _context.StudentRegisterations select s;
        //    if (!String.IsNullOrEmpty(searchData))
        //    {
        //        searchWith = searchWith.ToLower();

        //        switch (searchWith)
        //        {
        //            case "id":
        //                user = user.Where(s => s.Id == Int32.Parse(searchData));
        //                return "id6";
        //            case "name":
        //                user = user.Where(s => s.Name.Contains(searchData));
        //                return "id5";
        //            case "program":
        //                user = user.Where(s => s.Program.Contains(searchData));
        //                return "id4";
        //            case "detail":
        //                user = user.Where(s => s.Detail.Contains(searchData));
        //                return "id3";
        //            case "filename":
        //                user = user.Where(s => s.Filename.Contains(searchData));
        //                return "id2";
        //            default:
        //                return "id1";
        //        }
        //    }
        //    else
        //        return null;

           
        //}
        // GET: api/StudentRegisterations
        [HttpGet ("Get")]
        public IEnumerable<StudentRegisteration> GetStudentRegisterations(int pageNo=1,string searchWith="",string searchData="1", string sortData="", int pageSize=5)
        {
            // _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Name);
            pageNo = pageNo - 1;
            sortData = sortData.ToLower();
            var user = from s in _context.StudentRegisterations select s;

            user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Id);


           // var users = _context.UserModels.OrderBy(p => EF.Property<object>(p, sort));

            switch (sortData)
            {
                case "id":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Id);
                    break;

                case "name":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Name);
                    break;

                case "program":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Program);
                    break;

                case "detail":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Detail);
                    break;
                case "filename":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Filename);
                    break;
                default:
                    break;

            }
            if (!String.IsNullOrEmpty(searchData))
            {

                searchWith = searchWith.ToLower();

                switch (searchWith)
                {
                    case "id":
                        user = user.Where(s => s.Id == Int32.Parse(searchData));
                        break;

                    case "name":
                        user = user.Where(s => s.Name.Contains(searchData));
                        break;


                    case "detail":
                        user = user.Where(s => s.Detail.Contains(searchData));
                        break;

                    case "program":
                        user = user.Where(s => s.Program.Contains(searchData));
                        break;

                    case "filename":
                        user = user.Where(s => s.Filename.Contains(searchData));
                        break;

                    default:
                        break;
                }

            }
            else
                return null;

            return user.Skip(pageNo * pageSize).Take(pageSize);
        }



        [HttpGet("GetAll")]
        public IEnumerable<StudentRegisteration> GetStudentRegisterations1(int pageNo = 1, string searchWith = "", string searchData = "1", string sortData = "", int pageSize = 5)
        {
            // _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Name);
            pageNo = pageNo - 1;
            sortData = sortData.ToLower();
            var user = from s in _context.StudentRegisterations select s;

            user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Id);


            switch (sortData)
            {
                case "id":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Id);
                    break;

                case "name":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Name);
                    break;

                case "program":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Program);
                    break;

                case "detail":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Detail);
                    break;
                case "filename":
                    user = _context.StudentRegisterations.OrderBy(StudentRegisteration => StudentRegisteration.Filename);
                    break;
                default:
                    break;

            }
            if (!String.IsNullOrEmpty(searchData))
            {

                searchWith = searchWith.ToLower();

                switch (searchWith)
                {
                    case "id":
                        user = user.Where(s => s.Id == Int32.Parse(searchData));
                        break;

                    case "name":
                        user = user.Where(s => s.Name.Contains(searchData));
                        break;


                    case "detail":
                        user = user.Where(s => s.Detail.Contains(searchData));
                        break;

                    case "program":
                        user = user.Where(s => s.Program.Contains(searchData));
                        break;

                    case "filename":
                        user = user.Where(s => s.Filename.Contains(searchData));
                        break;

                    default:
                        break;
                }

            }
            else
                return null;

            return user.Skip(pageNo * pageSize).Take(pageSize);
        }


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


      //  public async Task<IActionResult> Index(string sOrder)



        private bool StudentRegisterationExists(int id)
        {
            return _context.StudentRegisterations.Any(e => e.Id == id);
        }
    }
}