using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DemoEntityFramework.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoEntityFramework.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public StudentController(ApplicationDbContext context)
        {
            this.context = context;
        }

        #region GetAll

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudents()
        {
            return await context.Students.ToListAsync();
        }
        #endregion

        #region GetByID

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentModel>> GetStudent(int id)
        {
            var Student = await context.Students.FindAsync(id);

            if (Student == null) 
            {
                return NotFound();
            }
            return Student;
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, StudentModel Student)
        {
            if (id != Student.StudentId)
            {
                return BadRequest();
            }

            try
            {
                context.Update(Student);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!StudentExists(id))
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

        #region Insert
        [HttpPost]
        public async Task<ActionResult<StudentModel>> AddStudent(StudentModel student)
        {
            context.Students.Add(student);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        private bool StudentExists(int id)
        {
            return context.Students.Any(e => e.StudentId == id);
        }
    }
}
