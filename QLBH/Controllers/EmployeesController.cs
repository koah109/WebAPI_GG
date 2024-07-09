using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public EmployeesController(ApplicationDBContext context)
        {
            _context = context;
        }

        #region HttpGet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {

            return await _context.Employee.ToListAsync();
            
        }

        [HttpGet ("{Emp_code}")]
        public async Task<ActionResult<Employee>> GetEmployee(int Emp_code)
        {
            var employee = await _context.Employee.FindAsync(Emp_code);

            return employee;
        }
        #endregion


        #region HttpPost
        [HttpPost ("{Emp_code}")]
        public async Task<ActionResult<Employee>> PostEmployees(Employee employees)
        {
            var employee = _context.Employee.AddAsync(employees);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Employee),new {emp_code = employees.Emp_code }, employees);
        }
        #endregion

        #region HttpPut
        [HttpPut("{Emp_code}")]
        public async Task<IActionResult> PutEmployee(int Emp_code, Employee emp)
        {
            if (emp == null)
            {
                return BadRequest();
            }
            _context.Entry(emp).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!EmployeeExist(Emp_code))
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

        #region HttpDelete
        [HttpDelete("{Emp_code}")]
        public async Task<IActionResult> DeleteEmployee()
        {
            var emp = await _context.Employee.FindAsync();
            if (emp == null)
            {
                return NotFound();
            }
            _context.Remove(emp);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        #endregion 
        public bool EmployeeExist(int Employee_code)
        {
            return _context.Employee.Any(e=>e.Emp_code == Employee_code);
        }
    }
}
