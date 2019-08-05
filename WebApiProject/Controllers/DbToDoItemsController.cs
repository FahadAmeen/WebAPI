using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class DbToDoItemsController : ControllerBase
    {
        private readonly DBContext _context;
        private CacheClass _cache1;
        private string _modelName = "ToDoItems";
        private int _defaultCacheDuration = 1;


        public DbToDoItemsController(DBContext context, IMemoryCache memoryCache)
        {
            _cache1 = new CacheClass(memoryCache);
            _context = context;
        }

        // GET: api/DbToDoItems
        [HttpGet]
        public async Task<List<ToDoItem>> GetToDoItems(string inColumn = "", string forWord = "", string sortBy = "Id",
            int pageNo = 0, int pageSize = 5)
        {
            //IMP : Be very careful abt the sortBy property. It should be exactly as the name of the property i.e. very case sensitive
            pageNo = pageNo - 1;

            var cacheKey = "Get_Items_All_" + inColumn + forWord + sortBy + pageNo + pageSize;

            List<object> alltoDoItems = _cache1.Search(cacheKey);


            if (alltoDoItems == null) //no entry in cache hence create an entry in cache
            {
                var convertedtoDoItems = _context.ToDoItems; //get toDoItems list from Db
                var toDoItems = convertedtoDoItems.OrderBy(p => EF.Property<object>(p, sortBy));

                var selecttoDoItems = from s in toDoItems select s;

                if (!String.IsNullOrEmpty(forWord))
                {
                    switch (inColumn)
                    {
                        case "Id":
                            selecttoDoItems = selecttoDoItems.Where(s => s.Id == Int32.Parse(forWord));
                            break;

                        default:
                            selecttoDoItems = selecttoDoItems.Where(s => EF.Property<string>(s, inColumn).Contains(forWord));
                            break;
                    }
                }

                if (pageNo > -1)
                {
                    selecttoDoItems = selecttoDoItems.Skip(pageNo * pageSize).Take(pageSize);
                }

                List<object> convertedUSer = new List<object>(selecttoDoItems);
                //store the searched results
                _cache1.updateCache(cacheKey, _modelName, _defaultCacheDuration, convertedUSer);
                return selecttoDoItems.ToList();
            }

            List<ToDoItem> ConvertedtoDoItems = new List<ToDoItem>();
            for (int i = 0; i < alltoDoItems.Count; i++)
            {
                ToDoItem newuser = (ToDoItem)alltoDoItems[i];
                ConvertedtoDoItems.Add(newuser);
            }

            return ConvertedtoDoItems.ToList();

        }



        [HttpGet("getCount")]
        public int GetCountOfItems()
        {
            var allItems = _context.ToDoItems;
            return allItems.Count();
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