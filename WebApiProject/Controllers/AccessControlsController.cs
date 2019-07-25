using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProject.Data;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessControlsController : ControllerBase
    {
        private readonly DBContext _context;

        public AccessControlsController(DBContext context)
        {
            _context = context;
        }

        // GET: api/AccessControls
        [HttpGet]
        public IEnumerable<AccessControl> GetAccessControl()
        {
            return _context.AccessControl;
        }
    }
}