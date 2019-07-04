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
    public class DbToDoItemsController : ControllerBase
    {
        private readonly DBContext _context;

        public DbToDoItemsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/DbToDoItems
        [HttpGet]
        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _context.ToDoItems;
        }

        // GET: api/DbToDoItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoItem = await _context.ToDoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return Ok(toDoItem);
        }

        // PUT: api/DbToDoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem([FromRoute] long id, [FromBody] ToDoItem toDoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
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

        // POST: api/DbToDoItems
        [HttpPost]
        public async Task<IActionResult> PostToDoItem([FromBody] ToDoItem toDoItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ToDoItems.Add(toDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItem", new { id = toDoItem.Id }, toDoItem);
        }

        // DELETE: api/DbToDoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return Ok(toDoItem);
        }

        private bool ToDoItemExists(long id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }
    }
}