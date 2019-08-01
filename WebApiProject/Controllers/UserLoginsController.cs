using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Helper;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly DBContext _context;
        private static readonly string key = "E546C8DF278CD5931069B522E695D4F2";
        public UserLoginsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/UserLogins
        [HttpGet]
        public bool GetUserLogin(string username, string password)
        {



            var allRecords = _context.UserLogin;
            var selectUsers = from s in allRecords select s;

            if (!String.IsNullOrEmpty(password) && !(username == "") && !(username == null))
            {
                //got all users with the current user name 
                var matchingUsers = selectUsers.Where(s => s.email == username).ToList();
                if (matchingUsers.Count() > 0)
                {
                    for (int i = 0; i < matchingUsers.Count(); i++)
                    {
                        UserLogin currentUser = (UserLogin)matchingUsers[i];
                        var encryptedBySecondEncrypt = EncryptDecrpt.Encrypt(password);
                        var decryptedBySecondDecrypt = EncryptDecrpt.Decrypt(encryptedBySecondEncrypt);
                        var decryptedUserPassword = EncryptDecrpt.Decrypt(currentUser.SPassword);
                        var issEqual = (decryptedUserPassword == decryptedBySecondDecrypt);

                        return issEqual;

                    }
                }
            }
             return false;
            
        }

        // GET: api/UserLogins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLogin = await _context.UserLogin.FindAsync(id);

            if (userLogin == null)
            {
                return NotFound();
            }

            return Ok(userLogin);
        }

        // PUT: api/UserLogins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserLogin([FromRoute] int id, [FromBody] UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userLogin.id)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(id))
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

        // POST: api/UserLogins
        [HttpPost]
        public async Task<IActionResult> PostUserLogin([FromBody] UserLogin userLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserLogin.Add(userLogin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserLogin", new { id = userLogin.id }, userLogin);
        }

        // DELETE: api/UserLogins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userLogin = await _context.UserLogin.FindAsync(id);
            if (userLogin == null)
            {
                return NotFound();
            }

            _context.UserLogin.Remove(userLogin);
            await _context.SaveChangesAsync();

            return Ok(userLogin);
        }

        private bool UserLoginExists(int id)
        {
            return _context.UserLogin.Any(e => e.id == id);
        }
    }
}