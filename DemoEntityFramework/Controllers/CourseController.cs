using DemoEntityFramework.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEntityFramework.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GetCourses

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseModel>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }
        #endregion

        #region GetCourse
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseModel>> GetCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null) 
            {
                return NotFound();
            }
            else
            {
                return course;
            }
        }
        #endregion

        #region insert
        [HttpPost]
        public async Task<ActionResult<CourseModel>> addCourse(CourseModel course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new {id = course.CourseId},course);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseModel course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }
            try
            {
                _context.Update(course);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                if (!CourseExists(id))
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
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);

            if(course == null)
            {
                return NoContent();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion
        private bool CourseExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}
