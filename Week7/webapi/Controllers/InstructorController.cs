using System.Collections.Generic;
using System.Linq;
using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly SchoolContext _dbContext;

        public InstructorController(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET
        [HttpGet]
        public ActionResult<List<Instructor>> GetAllInstructors()
        {
            var list = _dbContext.Instructor.ToList();
            return Ok(list);
        }

        // POST
        [HttpPost]
        public ActionResult<Instructor> CreateInstructor(Instructor instructor)
        {
            _dbContext.Instructor.Add(instructor);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE
        [HttpDelete("{instructorId}")]
        public ActionResult DeleteInstructor(long instructorId)
        {
            var instructor = new Instructor
            {
                InstructorId = instructorId
            };

            _dbContext.Attach(instructor);
            _dbContext.Remove(instructor);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}