using System.Collections.Generic;
using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        // GET
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return Ok(GetStudents());
        }

        private List<Student> GetStudents()
        {
            return InMemory.Students;
        }
    }
}