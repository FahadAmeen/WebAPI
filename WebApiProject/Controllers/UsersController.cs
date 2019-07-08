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

        // GET: api/Users
        [HttpGet("GetCount")]
        public int GetCount()
        {
            return _context.Users.Count();
        }

        [HttpGet("GetAll")]
        public async Task<IList<User>> Search(string inColumn = "", string forWord = "", string sortBy = "Id", int pageNo = 0, int pageSize = 5)
        {   //IMP : Be very careful abt the sortBy property. It should be exactly as the name of the property i.e. very case sensitive
            pageNo = pageNo - 1;

            var users = _context.Users.OrderBy(p => EF.Property<object>(p, sortBy));

            var selectUsers = from s in users select s;

            if (!String.IsNullOrEmpty(forWord))
            {
                switch (inColumn)
                {
                    case "Id":
                        selectUsers = selectUsers.Where(s => s.Id == Int32.Parse(forWord));
                        break;

                    default:
                        selectUsers = selectUsers.Where(s => EF.Property<string>(s, inColumn).Contains(forWord));
                        break;
                }
            }

            if (pageNo > -1)
            {
                return await selectUsers.Skip(pageNo * pageSize).Take(pageSize).ToArrayAsync();
            }
            else
            {
                return await selectUsers.ToArrayAsync();
            }

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