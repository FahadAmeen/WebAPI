using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiProject.Data;
using WebApiProject.Helper_classes;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly DBContext _context;
        public LoginsController(DBContext context)
        {
            
            _context = context;
        }

        // GET: api/Logins
        [EnableCors]
        [HttpGet]
        public bool GetLogin(string userName, string stringPassword )
        {

           
            var allRecords = _context.Login;
            var selectUsers = from s in allRecords select s;

            if (!String.IsNullOrEmpty(stringPassword) && !(userName == "") && !(userName==null))
            {
                //got all users with the current user name 
                var matchingUsers = selectUsers.Where(s => s.UserName == userName).ToList();
                if (matchingUsers.Count()>0)
                {
                    for (int i = 0; i < matchingUsers.Count(); i++)
                    {
                        Login currentUser = (Login)matchingUsers[i];
                        var encryptedBySecondEncrypt = Encryptor.Encrypt(stringPassword);
                        var decryptedBySecondDecrypt = Encryptor.Decrypt(encryptedBySecondEncrypt);
                        var decryptedUserPassword = Encryptor.Decrypt(currentUser.Password);
                        var issEqual = (decryptedBySecondDecrypt== decryptedUserPassword);
                       
                       return issEqual;
                       
                    }
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        // GET: api/Logins/5
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.FindAsync(id);

            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin([FromRoute] int id, [FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.UserId)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Login.Add(login);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogin", new { id = login.UserId }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return Ok(login);
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.UserId == id);
        }
    }
}