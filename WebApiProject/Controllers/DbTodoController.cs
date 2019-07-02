using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //this indicates that this controller responds to web api requests. 

    public class DbTodoController : Controller
    {
        //private readonly TodoContext _context;

        private List<ToDoItem> _context = new List<ToDoItem>();

        public DbTodoController(TodoContext context)
        {
            // _context = context;

            //if (!_context.ToDoItems.Any())
            //{
            //    //create a new ToDoItems if collection is empty, which means you can't delete all TodoItems.
            //    _context.ToDoItems.Add(new ToDoItem {Name = "Item1"});
            //    _context.SaveChanges();
            //} 
            if (_context.Count == 0)
            {
                _context.Add(new ToDoItem() {Name = "Item1"});
            }
        }

        // POST: api/Todo
        [HttpPost]
        public List<ToDoItem> PostTodoItem(ToDoItem item)
        {
            //_context.ToDoItems.Add(item);
            _context.Add(item);

            // await _context.SaveChangesAsync();
            // return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
            return _context;
        }

        //put: api/Todo
        [HttpPut("{id}")]
        public List<ToDoItem> PutTodoItem(long id, ToDoItem item)
        {
            //if (id != item.Id)
            //{
            //    return BadRequest();
            //}

            var index = _context.FindIndex(c => c.Id == id);
            _context[index].Name = item.Name;
            _context[index].IsComplete = item.IsComplete;
            //_context.Entry(item).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            //return NoContent();
            return _context;
        }




        //GET = api/Todo
        [HttpGet]
        public List<ToDoItem> GetToDoItems()
        {
            //return await _context.ToDoItems.ToListAsync();
            return _context;
        }

        //GET = api/Todo/3
        [HttpGet("{id}")]
        public int GetTodoItem(long id)
        {
            //var todoItem = await _context.ToDoItems.FindAsync(id);
            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            //return todoItem;
            var index = _context.FindIndex(c => c.Id == id);
            return index;
        }





        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            //var todoItem = await _context.ToDoItems.FindAsync(id);

            //if (todoItem == null)
            //{
            //    return NotFound();
            //}

            //_context.ToDoItems.Remove(todoItem);
            //await _context.SaveChangesAsync();

            //return NoContent();
            var index = _context.FindIndex(c => c.Id == id);
            _context.RemoveAt(index);
            return NoContent();

        }
    }
}