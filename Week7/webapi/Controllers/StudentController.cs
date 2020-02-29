using System.Collections.Generic;
using System.Linq;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _dbContext;
        public StudentController(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET
        [HttpGet]
        public ActionResult<List<Student>> GetAllStudents()
        {
            var list = _dbContext.Student.ToList();
            return Ok(list);
        }

        // POST
        [HttpPost]
        public ActionResult<Student> CreateStudent(Student student)
        {
            _dbContext.Student.Add(student);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE
        [HttpDelete("{studentId}")]
        public ActionResult DeleteStudent(long studentId) 
        {
            var student = new Student
            {
                StudentId = studentId
            };

            _dbContext.Attach(student);
            _dbContext.Remove(student);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}