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
    public class StudentRegisterationsController : ControllerBase
    {
        private readonly StudentRegisterationBL _userBL;

        public StudentRegisterationsController(StudentRegisterationBL userBl)
        {
            _userBL = userBl;

        }
        [Route( "GetAll")]
        public int GetCount()
        {
            return _userBL.GetCount();
        }

        // GET: api/StudentRegisterations
        [HttpGet]
        public async Task<IEnumerable<StudentRegisteration>> GetStudentRegisterationsAsync(int pageNo = 1, string searchWith = "Id", string searchData = "", string sortData = "Id", int pageSize = 5)
        {

            return await _userBL.GetStudentRegisterationsAsync(pageNo, searchWith, searchData, sortData, pageSize);
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
                await _userBL.GetStudentRegisteration(id);

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
                await _userBL.PutStudentRegisteration(id, studentRegisteration);
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

            await _userBL.PostStudentRegisteration(studentRegisteration);

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
                await _userBL.DeleteStudentRegisteration(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(ModelState);
            }
        }

        private bool StudentRegisterationExists(int id)
        {
            return _userBL.StudentRegisterationExists(id);
        }
    }
}