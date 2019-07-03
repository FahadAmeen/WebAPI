﻿using System;
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
    [ApiController] //this indicates that this controller responds to web api requests. 


    public class DbTodoController : Controller
    {
        private readonly DBContext _context;
        public DbTodoController(DBContext context)
        {
            _context = context;

            if (!_context.ToDoItems.Any())
            {
                // Create a new ToDoItem if collection is empty,
                // which means you can't delete all ToDoItems.
                _context.ToDoItems.Add(new ToDoItem { Name = "Item1" });
                _context.SaveChanges();
            }
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(long id, ToDoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Todo
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem item)
        {
            _context.ToDoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoItem), new { id = item.Id }, item);
        }


        // GET: api/Todo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        // GET: api/Todo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(long id)
        {
            var ToDoItem = await _context.ToDoItems.FindAsync(id);

            if (ToDoItem == null)
            {
                return NotFound();
            }

            return ToDoItem;
        }





        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItem(long id)
        {
            var ToDoItem = await _context.ToDoItems.FindAsync(id);

            if (ToDoItem == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(ToDoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}