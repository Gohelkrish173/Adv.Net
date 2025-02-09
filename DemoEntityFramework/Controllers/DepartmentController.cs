using DemoEntityFramework.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoEntityFramework.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GetDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> getDepartments()
        {
            return await _context.Departments.ToListAsync();
        }
        #endregion

        #region GetDepartment
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentModel>> getDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null) 
            {
                return NotFound();
            }
            else
            {
                return department;
            }
        }
        #endregion

        #region Insert
        [HttpPost]
        public async Task<ActionResult<DepartmentModel>> insertDepartment(DepartmentModel department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("getDepartment",new { id = department.DepartmentId },department);
        }
        #endregion

        #region Update
        [HttpPut("{id}")]
        public async Task<IActionResult> updateDepartment(int id, DepartmentModel department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            try
            {
                _context.Update(department);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                if (!DepartmentExist(id))
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
        public async Task<IActionResult> deleteDepartment(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) 
            {
                return NotFound();
            }

            _context.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        private bool DepartmentExist(int id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
