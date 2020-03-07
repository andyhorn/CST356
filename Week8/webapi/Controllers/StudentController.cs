using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _studentService = studentService;
            _logger = logger;
        }

        // GET
        [HttpGet]
        public ActionResult<List<StudentViewModel>> GetAllStudents()
        {
            try
            {
                var students = _studentService.GetAllStudents();
                return students;
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<StudentViewModel>> CreateStudent(Student student)
        {
            var created = await _studentService.CreateStudentAsync(student);

            if (created)
            {
                return StatusCode(StatusCodes.Status201Created);
            }

            return BadRequest(new {
                Error = "Unable to create user"
            });
        }

        // DELETE
        [HttpDelete]
        [Route("{studentId}")]
        public async Task<ActionResult> DeleteStudent(long studentId) 
        {
            var student = new Student
            {
                StudentId = studentId
            };

            var deleted = await _studentService.DeleteStudentAsync(studentId);

            if (deleted)
            {
                return NoContent();
            }

            return BadRequest(new {
                Error = "Unable to delete student"
            });
        }
    }
}