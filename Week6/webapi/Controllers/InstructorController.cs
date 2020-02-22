using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstructorController : Controller
    {
        private readonly ILogger<InstructorController> _logger;

        public InstructorController(ILogger<InstructorController> logger)
        {
            _logger = logger;
        }

        // GET Instructor list
        [HttpGet]
        public ActionResult<List<Instructor>> Get()
        {
            return Ok(GetInstructors());
        }

        private List<Instructor> GetInstructors()
        {
            return InMemory.Instructors;
        }
    }
}