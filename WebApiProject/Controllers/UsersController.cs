using BussinessLogic;
using BussinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Func<string, IUserModelBL> _userBl;

        public UsersController(Func<string, IUserModelBL> userBl)
        {
            _userBl = userBl;

        }
       
        

        // GET: api/Users
        [HttpGet("GetCount")]
        public int GetCount()
        {
            return _userBl("User").TotalRecords();
        }

        [HttpGet("GetAll")]
        public async Task<IList<User>> Search(string inColumn = "", string forWord = "", string sortBy = "Id", int pageNo = 0, int pageSize = 5)
        {
            var List_caster = await _userBl("User").GetUsers(inColumn, forWord, sortBy, pageNo, pageSize);
            List<User> enumerable_caster = List_caster.Cast<User>().ToList();
            return enumerable_caster;

        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userBl("User").Get(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
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

           

            try
            {
                await _userBl("User").Put(id, user);
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

            await _userBl("User").Post(user);

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

            try
            {
                await _userBl("User").Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        private bool UserExists(int id)
        {
            return _userBl("User").Exists(id);
        }
    }
}