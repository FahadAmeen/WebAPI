using BussinessLogic;
using BussinessObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisteredUsersController : ControllerBase
    {


        private readonly Func<string, IUserModelBL> _userBl;
        public RegisteredUsersController(Func<string, IUserModelBL> userBl)
        {
            _userBl = userBl;
        }


        //api/RegisteredUsers/GetAll?pageIndex=1&sortOrder=name&col=password&val=password7&pageSize=16
        [HttpGet("GetAll")]
        public async Task<IEnumerable<RegisteredUser>> Indexx(int pageIndex = 1, string sortOrder = "no", string col = "", string val = "",
            int pageSize = 5)
        {
            var List_caster = await _userBl("RegisteredUser").GetUsers(sortOrder, col , val, pageIndex, pageSize);
            IEnumerable<RegisteredUser> enumerable_caster = List_caster.Cast<RegisteredUser>().ToList();
            return enumerable_caster;

        }


        // GET: api/RegisteredUsers
        [HttpGet("GetCount")]
        public int GetCount()
        {
            return _userBl("RegisteredUser").TotalRecords();
        }




        // GET: api/RegisteredUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegisteredUser([FromRoute] int id)
        {
            RegisteredUser tempUser = (RegisteredUser) await _userBl("RegisteredUser").Get(id);

            return Ok(tempUser);
        }

        // PUT: api/RegisteredUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegisteredUser([FromRoute] int id, [FromBody] RegisteredUser registeredUser)
        {
            try
            {
                await _userBl("RegisteredUser").Put(id, registeredUser);
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        // POST: api/RegisteredUsers
        [HttpPost]
        public async Task<IActionResult> PostRegisteredUser([FromBody] RegisteredUser registeredUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userBl("RegisteredUser").Post(registeredUser);
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
            

            return CreatedAtAction("GetRegisteredUser", new { id = registeredUser.Id }, registeredUser);
        }

        // DELETE: api/RegisteredUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegisteredUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                await _userBl("RegisteredUser").Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
        }

        private bool RegisteredUserExists(int id)
        {
            return _userBl("RegisteredUser").Exists(id);
        }
    }
}