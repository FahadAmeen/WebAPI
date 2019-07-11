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
        private readonly IUserModelBL _userBL;

        public StudentRegisterationsController(IUserModelBL userBl)
        {
            _userBL = userBl;

        }
        [Route( "GetAll")]
        public int GetCount()
        {
            return _userBL.TotalRecords();
        }

        // GET: api/StudentRegisterations
        [HttpGet]
        public async Task<IEnumerable<StudentRegisteration>> GetStudentRegisterationsAsync(int pageNo = 1, string searchWith = "Id", string searchData = "", string sortData = "Id", int pageSize = 5)
        {

            var List_caster = await _userBL.GetUsers(sortData, searchWith, searchData, pageSize, pageNo);
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
                await _userBL.Get(id);

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
                await _userBL.Put(id, studentRegisteration);
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

            await _userBL.Post(studentRegisteration);

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
                await _userBL.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
        }

        private bool StudentRegisterationExists(int id)
        {
            return _userBL.Exists(id);
        }
    }
}