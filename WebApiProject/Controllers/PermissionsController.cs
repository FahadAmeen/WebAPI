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
    public class PermissionsController : ControllerBase
    {
        private readonly DBContext _context;

        public PermissionsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/Permissions
        [HttpGet]
        public IEnumerable<Permission> GetPermission()
        {
            return _context.Permission;
        }

        // GET: api/Permissions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPermission([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permission = await _context.Permission.FindAsync(id);

            if (permission == null)
            {
                return NotFound();
            }

            return Ok(permission);
        }

        // PUT: api/Permissions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermission([FromRoute] string id, [FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != permission.Name)
            {
                return BadRequest();
            }

            _context.Entry(permission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PermissionExists(id))
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

        // POST: api/Permissions
        [HttpPost]
        public async Task<IActionResult> PostPermission([FromBody] Permission permission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Permission.Add(permission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPermission", new { id = permission.Name }, permission);
        }

        // DELETE: api/Permissions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var permission = await _context.Permission.FindAsync(id);
            if (permission == null)
            {
                return NotFound();
            }

            _context.Permission.Remove(permission);
            await _context.SaveChangesAsync();

            return Ok(permission);
        }

        private bool PermissionExists(string id)
        {
            return _context.Permission.Any(e => e.Name == id);
        }
    }
}