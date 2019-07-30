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
    public class ResetPasswordsController : ControllerBase
    {
        private readonly DBContext _context;

        public ResetPasswordsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/ResetPasswords
        //[HttpGet]
        //public IEnumerable<ResetPassword> GetResetPassword()
        //{
        //    return _context.ResetPassword;
        //}


        // GET: api/ResetPasswords/useremail
        [HttpGet("{userEmailPassed}")]
        ////public Login GetLogin([FromRoute] string userEmailPassed)
        public bool GetResetRecord(string userEmailPassed)
        {
            
            ResetPassword latestLoginRecord;
            List<ResetPassword> allMatchingRecords;

            if (!String.IsNullOrEmpty(userEmailPassed))
            {
                allMatchingRecords = _context.ResetPassword.Where(s => s.userEmail == userEmailPassed).ToList();
                if (allMatchingRecords.Count() < 1)
                {
                    return false;
                }

                allMatchingRecords = allMatchingRecords.OrderBy(item => item.resetRequestTime).ToList();
                latestLoginRecord = allMatchingRecords[allMatchingRecords.Count() - 1];
                var isValid = latestLoginRecord.expiryTime > DateTime.Now;
                if (latestLoginRecord.expiryTime > DateTime.Now)
                {
                    return true;
                }
            }
            
            return false;
        }

  
        // PUT: api/ResetPasswords/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResetPassword([FromRoute] int id, [FromBody] ResetPassword resetPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != resetPassword.id)
            {
                return BadRequest();
            }

            _context.Entry(resetPassword).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResetPasswordExists(id))
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

        // POST: api/ResetPasswords
        [HttpPost]
        public async Task<IActionResult> PostResetPassword([FromBody] ResetPassword resetPassword)
        {   
            resetPassword.resetRequestTime = DateTime.Now;
            resetPassword.expiryTime = resetPassword.resetRequestTime.AddDays(1);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ResetPassword.Add(resetPassword);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostResetPassword", new { id = resetPassword.id }, resetPassword);
        }

        // DELETE: api/ResetPasswords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResetPassword([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resetPassword = await _context.ResetPassword.FindAsync(id);
            if (resetPassword == null)
            {
                return NotFound();
            }

            _context.ResetPassword.Remove(resetPassword);
            await _context.SaveChangesAsync();

            return Ok(resetPassword);
        }

        private bool ResetPasswordExists(int id)
        {
            return _context.ResetPassword.Any(e => e.id == id);
        }
    }
}