using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredUsersController : ControllerBase
    {
        private readonly DBContext _context;
        public RegisteredUsersController(DBContext context)
        {
            _context = context;
        }


        //api/RegisteredUsers/GetAll?pageIndex=1&sortOrder=name&col=password&val=password7&pageSize=16
        [HttpGet("GetAll")]
        public IEnumerable<RegisteredUser> Indexx(int pageIndex, string sortOrder = "no", string col="name",string val = "userName",
            int pageSize = 10)
        {
            pageIndex = pageIndex - 1;
            sortOrder = sortOrder.ToLower();
            var user = from s in _context.RegisteredUsers
                select s;
            switch (sortOrder)
            {
                case "id":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Id);
                    break;
                case "name":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Name);
                    break;
                case "email_address":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Email_address);
                    break;
                case "file_name":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.FileName);
                    break;
                case "job_type":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Job_type);
                    break;
                case "phone_number":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Phone_number);
                    break;
                case "password":
                    user = _context.RegisteredUsers.OrderBy(RegisteredUser => RegisteredUser.Password);
                    break;
                default:
                    break;
                //return user.Skip(pageIndex * pageSize).Take(pageSize);
            }

            if (!String.IsNullOrEmpty(val))
            {
                col = col.ToLower();
                switch (col)
                {
                    case "id":
                        user = user.Where(s => s.Id == Int32.Parse(val));
                        break;
                    case "name":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Name, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "email_address":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Email_address, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "file_name":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.FileName, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "job_type":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Job_type, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "phone_number":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Phone_number, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    case "password":
                        user = _context.RegisteredUsers.Where(p =>
                            string.Equals(p.Password, val, StringComparison.OrdinalIgnoreCase));
                        break;
                    default:
                        break;
                }

            }
            else
            {
                return null;
            }
            return user.Skip(pageIndex * pageSize).Take(pageSize);
        }

        // GET: api/RegisteredUsers
        [HttpGet]
        public IEnumerable<RegisteredUser> GetRegisteredUsers()
        {
            return _context.RegisteredUsers;
        }

        //api/RegisteredUsers/name?val=userName
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Route("name")]
        public IQueryable<RegisteredUser> GetProductsByName(string val)
        {
           return _context.RegisteredUsers.Where(p => string.Equals(p.Name, val,StringComparison.OrdinalIgnoreCase));
        }

        //api/RegisteredUsers/emailAddress?val=userName@gmail.com
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Route("emailAddress")]
        public IQueryable<RegisteredUser> GetProductsByEmail(string val)
        {
            return _context.RegisteredUsers.Where(p => string.Equals(p.Email_address, val, StringComparison.OrdinalIgnoreCase));
         }

        //api/RegisteredUsers/phoneNumber?val=923367455435 ---  WITHOUT '+' CHAR IN THE BEGINNING OF NUMBER  ----
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Route("phoneNumber")]
        public IQueryable<RegisteredUser> GetProductsByNumber(string val)
        {
            return _context.RegisteredUsers.Where(p => p.Phone_number.Contains(val));
        }


        //api/RegisteredUsers/password?val=password
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Route("password")]
        public IQueryable<RegisteredUser> GetProductsByPassword(string val)
        {
            return _context.RegisteredUsers.Where(p => string.Equals(p.Password, val, StringComparison.OrdinalIgnoreCase));
        }


        //api/RegisteredUsers/jobType?val=ty
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Route("jobType")]
        public IQueryable<RegisteredUser> GetProductsByJobType(string val)
        {
            return _context.RegisteredUsers.Where(p => string.Equals(p.Job_type, val, StringComparison.OrdinalIgnoreCase));
        }


        //api/RegisteredUsers/fileName?var=filename
        [Microsoft.AspNetCore.Mvc.HttpGet()]
        [Route("fileName")]
        public IQueryable<RegisteredUser> GetProductsByFileName(string val)
        {
            return _context.RegisteredUsers.Where(p => string.Equals(p.FileName, val, StringComparison.OrdinalIgnoreCase));
        }


        // GET: api/RegisteredUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegisteredUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = await _context.RegisteredUsers.FindAsync(id);

            if (registeredUser == null)
            {
                return NotFound();
            }

            return Ok(registeredUser);
        }

        // PUT: api/RegisteredUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisteredUser([FromRoute] int id, [FromBody] RegisteredUser registeredUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != registeredUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(registeredUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegisteredUserExists(id))
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

        // POST: api/RegisteredUsers
        [HttpPost]
        public async Task<IActionResult> PostRegisteredUser([FromBody] RegisteredUser registeredUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.RegisteredUsers.Add(registeredUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegisteredUser", new { id = registeredUser.Id }, registeredUser);
        }

        // DELETE: api/RegisteredUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisteredUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registeredUser = await _context.RegisteredUsers.FindAsync(id);
            if (registeredUser == null)
            {
                return NotFound();
            }

            _context.RegisteredUsers.Remove(registeredUser);
            await _context.SaveChangesAsync();

            return Ok(registeredUser);
        }

        private bool RegisteredUserExists(int id)
        {
            return _context.RegisteredUsers.Any(e => e.Id == id);
        }
    }
}