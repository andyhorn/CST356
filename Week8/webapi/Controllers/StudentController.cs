using System.Collections.Generic;
using System.Linq;
using Database;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // private readonly SchoolContext _dbContext;
        private readonly IStudentService _studentService;
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            // _dbContext = dbContext;
            _studentService = studentService;
            _logger = logger;
        }

        // GET
        [HttpGet]
        public ActionResult<List<StudentViewModel>> GetAllStudents()
        {
            try
            {
                // var list = _dbContext.Student.ToList();
                var students = _studentService.GetAllStudents();
                return students;
                // return Ok(list);
            }
            catch (System.Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            
        }

        // // POST
        // [HttpPost]
        // public ActionResult<StudentViewModel> CreateStudent(Student student)
        // {
        //     // _dbContext.Student.Add(student);
        //     // _dbContext.SaveChanges();

        //     return StatusCode(StatusCodes.Status201Created);
        // }

        // // DELETE
        // [HttpDelete("{studentId}")]
        // public ActionResult DeleteStudent(long studentId) 
        // {
        //     var student = new Student
        //     {
        //         StudentId = studentId
        //     };

        //     _dbContext.Attach(student);
        //     _dbContext.Remove(student);
        //     _dbContext.SaveChanges();

        //     return Ok();
        // }
    }
}