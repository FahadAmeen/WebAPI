using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;
using WebApiProject.Models.Wrappers;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserModelsController : ControllerBase
    {
        private readonly DBContext _context;

        public UserModelsController(DBContext context)
        {
            
            _context = context;
        }



        // [HttpGet]
        // [Produces("application/xml")]
        // public IEnumerable<UserModel> GetRecords()
        // {
        ////     System.Web.Http.GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
        ////new System.Net.Http.Formatting.QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));

        ////     System.Web.Http.GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
        ////         new System.Net.Http.Formatting.QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));

        //     return _context.UserModels;
        // }
















        //api/UserModel?page=3&limit=8&sort=Id
        [HttpGet]
        public async Task<IList<UserModel>> GetUsers(int page = 1, int limit = int.MaxValue, string sort = "Id", string search = "",string type="json")
        {
            var _page=page;
            var _limit=limit;
            var _sort=sort;
            var _search=search;
            var _type=type;
            switch (type)
            {
                case ("json"):
                    Request.Headers["Accept"] = "application/json";
                    return await Get(_page, _limit, _sort, _search, _type = "json");
                case ("xml"):
                    Request.Headers["Accept"] = "application/xml";
                    return await Get(_page, _limit, _sort, _search, _type = "xml");
                default:
                    return await Get();
            }
            
        }
        public async Task<IList<UserModel>> Get(int page = 1, int limit = int.MaxValue, string sort = "Id", string search = "", string type = "json")
        {
            var skip = (page - 1) * limit;
            if (search == "")
            {
                var users = _context.UserModels.OrderBy(p => EF.Property<object>(p, sort));

                return await users.Skip(skip).Take(limit).ToArrayAsync();
            }
            else
            {
                var users = _context.UserModels.Where(p => p.Id.ToString().Contains(search) || p.Name.Contains(search) || p.Email.Contains(search) || p.Comments.Contains(search) || p.Choice.Contains(search)).OrderBy(p => EF.Property<object>(p, sort)); //True version

                return await users.Skip(skip).Take(limit).ToArrayAsync();
            }
        }
        [HttpGet("{TotalcountResponse}")]
        public UserModelInfoWrapper CountAndData()
        {
            //int count = _context.UserModels.Count();
            UserModelInfoWrapper users = new UserModelInfoWrapper();
            users.count = _context.UserModels.Count();
            users.data = _context.UserModels.ToList();
            return users;
        }
        [HttpGet("{count}")]
        public int TotalRecords()
        {

            return _context.UserModels.Count();
        }


        // GET: api/UserModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _context.UserModels.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return Ok(userModel);
        }

        // PUT: api/UserModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel([FromRoute] int id, [FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
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

        // POST: api/UserModels
        [HttpPost]
        public async Task<IActionResult> PostUserModel([FromBody] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserModels.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserModel", new { id = userModel.Id }, userModel);
        }

        // DELETE: api/UserModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userModel = await _context.UserModels.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.UserModels.Remove(userModel);
            await _context.SaveChangesAsync();

            return Ok(userModel);
        }

        private bool UserModelExists(int id)
        {
            return _context.UserModels.Any(e => e.Id == id);
        }
    }
}