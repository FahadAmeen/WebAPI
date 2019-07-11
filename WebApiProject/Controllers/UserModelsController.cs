﻿using BussinessLogic;
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
    public class UserModelsController : ControllerBase
    {
        private readonly IUserModelBL _userBL;

        public UserModelsController(IUserModelBL userBl)
        {
            _userBL = userBl;
        }

        //api/UserModel?page=3&limit=8&sort=Id
        [HttpGet]
        public async Task<IList<UserModel>> GetUsers(int page = 1, int limit = int.MaxValue, string sort = "Id", string search = "")
        {
            var List_caster = await _userBL.GetUsers(page, limit, sort, search);
            List<UserModel> enumerable_caster = List_caster.Cast<UserModel>().ToList();
            return enumerable_caster;

        }

       
        [HttpGet("{count}")]
        public int TotalRecords()
        {

            return _userBL.TotalRecords();
        }


        // GET: api/UserModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _userBL.Get(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
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

            

            try
            {
                await _userBL.Put(id,userModel);
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

            await _userBL.Post(userModel);

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

            try
            {
                await _userBL.Delete(id);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        private bool UserModelExists(int id)
        {
            return _userBL.Exists(id);
        }
    }
}