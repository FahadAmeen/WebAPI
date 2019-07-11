using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration.Ini;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase 
    {
        private int _defaultCacheDuration = 1;
        private CacheClass _cache1;
        private string _modelName = "user";
        private DBContext _context;

        public UsersController(DBContext context, IMemoryCache memoryCache)
        {
            _cache1 = new CacheClass(memoryCache);
            
            _context = context;
        }
       
        // GET: api/Users
        [HttpGet]
        // checked ... verified
        public List<object> GetUsers()
        {
            var cacheKey = "Get_Users_";
            List<object> cachedObjects = _cache1.Search(cacheKey);
            if ( cachedObjects == null)
            {
                cachedObjects = new List<object>(_context.Users); 
                _cache1.updateCache(cacheKey, _modelName, _defaultCacheDuration, cachedObjects);
            }
            
            return (cachedObjects);
            
        }

        // GET: api/Users
        [HttpGet("GetCount")]
        // checked ...verified 
        public int GetCount()
        {
            var cacheKey = "Get_Users_Count";
            int objectsCount = _cache1.getCount(cacheKey);

            if (objectsCount == -1)
            {
                List<object> objectsToCount = new List<object>(_context.Users);
                _cache1.updateCache(cacheKey, _modelName, _defaultCacheDuration, objectsToCount.Count);
                return objectsToCount.Count;
            }

            return objectsCount;
            //return 1;
        }

        [HttpGet("GetAll")]
        public async Task<List<User>> SearchAsync(string inColumn = "", string forWord = "", string sortBy = "Id",
            int pageNo = 0, int pageSize = 5)
        {
            //IMP : Be very careful abt the sortBy property. It should be exactly as the name of the property i.e. very case sensitive
            pageNo = pageNo - 1;

            var cacheKey = "Get_Users_All_" + inColumn + forWord + sortBy + pageNo + pageSize;
            
           List<object> allUsers = _cache1.Search(cacheKey);

            
            if (allUsers == null) //no entry in cache hence create an entry in cache
            {
                var convertedUsers = _context.Users; //get users list from Db
                var users = convertedUsers.OrderBy(p => EF.Property<object>(p, sortBy)); 

                var selectUsers = from s in users select s;

                if (!String.IsNullOrEmpty(forWord))
                {
                    switch (inColumn)
                    {
                        case "Id":
                            selectUsers = selectUsers.Where(s => s.Id == Int32.Parse(forWord));
                            break;

                        default:
                            selectUsers = selectUsers.Where(s => EF.Property<string>(s, inColumn).Contains(forWord));
                            break;
                    }
                }

                if (pageNo > -1)
                {
                    selectUsers = selectUsers.Skip(pageNo * pageSize).Take(pageSize);
                }

                List<object> convertedUSer = new List<object>(selectUsers);
                //store the searched results
                _cache1.updateCache(cacheKey, _modelName, _defaultCacheDuration, convertedUSer);
                return selectUsers.ToList();
            }

            List<User> ConvertedUsers = new List<User>();
            for (int i = 0; i < allUsers.Count; i++)
            {
                User newuser = (User)allUsers[i];
                ConvertedUsers.Add(newuser);
            }

            return ConvertedUsers.ToList();
          
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        //checked ....
        public async Task<object> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cacheKey = "Get_Users_" + id;
            var cachedUser =  _cache1.TryGetById(cacheKey, id, "user", _defaultCacheDuration);
            
            if (cachedUser == null)
            {
                return NotFound();
            }

            return Ok(cachedUser);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _cache1.ClearCache("user");
            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(user);
            //Clearing cache
            _cache1.ClearCache("user");
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _cache1.ClearCache("user");

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}