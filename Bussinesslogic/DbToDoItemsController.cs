using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessObjects;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BussinessLogic
{
   
    public class DbToDoItemsController 
    {
        private readonly DBContext _context;

        public DbToDoItemsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/DbToDoItems
       
        public IEnumerable<ToDoItem> GetToDoItems()
        {
            return _context.ToDoItems;
        }

        // GET: api/DbToDoItems/5
        public async Task<ToDoItem> GetToDoItem( long id)
        {
            

            var toDoItem = await _context.ToDoItems.FindAsync(id);
            return toDoItem;
        }

        // PUT: api/DbToDoItems/5
        public async Task<string> PutToDoItem( long id, ToDoItem toDoItem)
        {
            

            _context.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
                {
                    return "fail";
                }
                else
                {
                    throw;
                }
            }

            return "pass";

        }

        // POST: api/DbToDoItems
       
        public async Task<string> PostToDoItem( ToDoItem toDoItem)
        {

            try
            {
                _context.ToDoItems.Add(toDoItem);
                await _context.SaveChangesAsync();
                return "pass";
            }
            catch (Exception e)
            {
                return "fail";
            }
        }

        // DELETE: api/DbToDoItems/5
        public async Task<string> DeleteToDoItem(long id)
        {

            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return "fail";
            }

            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return "pass";
        }

        private bool ToDoItemExists(long id)
        {
            return _context.ToDoItems.Any(e => e.Id == id);
        }
    }
}