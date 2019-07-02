﻿using System;
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
        
        private static List<ToDoItem> _context = new List<ToDoItem>();

        public DbTodoController()
        { 
        }

        // POST: api/Todo
        [HttpPost]
        public List<ToDoItem> PostTodoItem(ToDoItem item)
        {
            _context.Add(item);
            return _context;
        }

        //put: api/Todo
        [HttpPut("{id}")]
        public List<ToDoItem> PutTodoItem(long id, ToDoItem item)
        {
           
            var index = _context.FindIndex(c => c.Id == id);
            _context[index].Name = item.Name;
            _context[index].IsComplete = item.IsComplete;
            
            return _context;
        }




        //GET = api/Todo
        [HttpGet]
        public List<ToDoItem> GetToDoItems()
        {
            if (_context.Count == 0)
            {
                _context.Add(new ToDoItem() { Name = "HeyItem1" });
            }
            return _context;
        }

        //GET = api/Todo/3
        [HttpGet("{id}")]
        public ToDoItem GetTodoItem(long id)
        {
            if (_context.Count == 0)
            {
                _context.Add(new ToDoItem() { Name = "HeyItem1" });
            }
            var index = _context.FindIndex(c => c.Id == id);
            return _context[index];
        }





        // DELETE: api/Todo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            
            var index = _context.FindIndex(c => c.Id == id);
            _context.RemoveAt(index);
            return NoContent();

        }
    }
}