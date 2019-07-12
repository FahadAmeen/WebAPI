using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {

        private readonly ILogger<ExceptionController> _logger;
        public ExceptionController (ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }

        // GET: api/Exception
        [HttpGet]
        public IEnumerable<string> Get()
        {
            try
            {
                _logger.LogInformation("Could Break here:(");

            }
            catch(Exception e )
            {
                _logger.LogError(e, "It broke :(");
            }
            return new string[] { "value1", "value2" };
        }
       
    }
}
