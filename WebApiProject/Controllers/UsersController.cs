using BussinessLogic;
using BussinessObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserBL _userBl;

        public UsersController(UserBL userBl)
        {
            _userBl = userBl;

        }
       
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _userBl.GetUsers();
        }

        // GET: api/Users
        [HttpGet("GetCount")]
        public int GetCount()
        {
            return _userBl.GetCount();
        }

        [HttpGet("GetAll")]
        public async Task<IList<User>> Search(string inColumn = "", string forWord = "", string sortBy = "Id", int pageNo = 0, int pageSize = 5)
        {   //IMP : Be very careful abt the sortBy property. It should be exactly as the name of the property i.e. very case sensitive
            return await _userBl.Search(inColumn, forWord, sortBy, pageNo);

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
                await _userBl.GetUser(id);

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
                await _userBl.PutUser(id, user);
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

            await _userBl.PostUser(user);

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
                await _userBl.DeleteUser(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        private bool UserExists(int id)
        {
            return _userBl.UserExists(id);
        }
    }
}