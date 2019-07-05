using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration.Ini;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DBContext _context;

        public UsersController(DBContext context)
        {
            _context = context;
          
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users;
        }

        //[HttpGet("GetAll")]
        //public IEnumerable<User> GetUsers(int pageNo, int pageSize=5)
        //{
            
        //    pageNo = pageNo - 1;

        //    return _context.Users.Skip(pageNo * pageSize).Take(pageSize);
           
        //}

        //[HttpGet("Sort")]
        //public IEnumerable<User> GetUsers(string by, int pageNo=1, int pageSize = 5)
        //{
        //    pageNo = pageNo - 1;
        //    by = by.ToLower();

        //    var selectUsers = from s in _context.Users
        //        select s;
        //    switch (by)
        //    {
        //        case "id":
        //            selectUsers = _context.Users.OrderBy(user => user.Id);
        //            break;
                   
        //        case "name":
        //            selectUsers = _context.Users.OrderBy(user => user.Name);
        //            break;

        //        case "employee_role":
        //            selectUsers = _context.Users.OrderBy(user => user.Employe_Role);
        //            break;

        //        case "address":
        //            selectUsers = _context.Users.OrderBy(user => user.Address);
        //            break;

        //        case "file":
        //            selectUsers = _context.Users.OrderBy(user => user.File);
        //            break;

        //        default:
        //            break;


        //    }
        //    return selectUsers.Skip(pageNo * pageSize).Take(pageSize);
        //}



        [HttpGet("GetAll")]
        public IEnumerable<User> Search(string inColumn, string forWord,string sortBy="", int pageNo = 1, int pageSize = 5)
        {
            pageNo = pageNo - 1;
            sortBy = sortBy.ToLower();

            var selectUsers = from s in _context.Users
                select s;
            switch (sortBy)
            {
                case "id":
                    selectUsers = _context.Users.OrderBy(user => user.Id);
                    break;

                case "name":
                    selectUsers = _context.Users.OrderBy(user => user.Name);
                    break;

                case "employee_role":
                    selectUsers = _context.Users.OrderBy(user => user.Employe_Role);
                    break;

                case "address":
                    selectUsers = _context.Users.OrderBy(user => user.Address);
                    break;

                case "file":
                    selectUsers = _context.Users.OrderBy(user => user.File);
                    break;

                default:
                    break;


            }
            if (!String.IsNullOrEmpty(forWord))
            {
                
                inColumn = inColumn.ToLower();
                switch (inColumn)
                {
                    case "id":
                        selectUsers = selectUsers.Where(s => s.Id == Int32.Parse(forWord));
                        break;

                    case "name":
                        selectUsers = selectUsers.Where(s => s.Name.Contains(forWord));
                        break;


                    case "employee_role":
                        selectUsers = selectUsers.Where(s => s.Employe_Role.Contains(forWord));
                        break;

                    case "address":
                        selectUsers = selectUsers.Where(s => s.Address.Contains(forWord));
                        break;

                    case "file":
                        selectUsers = selectUsers.Where(s => s.File.Contains(forWord));
                        break;

                    default:
                        break;
                }
                
            }
            else
            {
                return null;
            }

            return selectUsers.Skip(pageNo * pageSize).Take(pageSize);

        }



        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }


        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}