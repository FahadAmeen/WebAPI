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
    public class StudentRegisterationsController : ControllerBase
    {
        private readonly Func<string, IUserModelBL> _userBl;

        public StudentRegisterationsController(Func<string, IUserModelBL> userBl)
        {
            _userBl = userBl;

        }
        [Route( "GetAll")]
        public int GetCount()
        {
            return _userBl("StudentRegisteration").TotalRecords();
        }

        // GET: api/StudentRegisterations
        [HttpGet]
        public async Task<IEnumerable<StudentRegisteration>> GetStudentRegisterationsAsync(int pageNo = 1, string searchWith = "Id", string searchData = "", string sortData = "Id", int pageSize = 5)
        {

            var List_caster = await _userBl("StudentRegisteration").GetUsers( searchWith, searchData, sortData, pageNo,pageSize);
            IEnumerable<StudentRegisteration> enumerable_caster = List_caster.Cast<StudentRegisteration>().ToList();
            return enumerable_caster;
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentRegisteration([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userBl("StudentRegisteration").Get(id);

            }
            catch (Exception EX_NAME)
            {
                return BadRequest(ModelState);
            }
            return Ok();
        }

        // PUT: api/StudentRegisterations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentRegisteration([FromRoute] int id, [FromBody] StudentRegisteration studentRegisteration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentRegisteration.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userBl("StudentRegisteration").Put(id, studentRegisteration);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentRegisterationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                }
            }

            return NoContent();
        }

        // POST: api/StudentRegisterations
        [HttpPost]
        public async Task<IActionResult> PostStudentRegisteration([FromBody] StudentRegisteration studentRegisteration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _userBl("StudentRegisteration").Post(studentRegisteration);

            return CreatedAtAction("GetStudentRegisteration", new { id = studentRegisteration.Id }, studentRegisteration);
        }

        // DELETE: api/StudentRegisterations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentRegisteration([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userBl("StudentRegisteration").Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
        }

        private bool StudentRegisterationExists(int id)
        {
            return _userBl("StudentRegisteration").Exists(id);
        }
    }
}