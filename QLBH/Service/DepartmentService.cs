using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Models.Request;

namespace QLBH.Service
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDBContext _context;
        public DepartmentService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> GetDepartmentById(int id)
        {
            return await _context.DEPARTMENT.ToListAsync();
        }


        public async Task<Department> PostDepartment(DepartmentRequest request)
        {
            var dept = new Department()
            {
                DEPT_NUMBER = request.DEPT_NAME,

                ADDRESS = request.ADDRESS,
            };
            _context.DEPARTMENT.Add(dept);
            await _context.SaveChangesAsync();
            return dept;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            Department dept = await _context.DEPARTMENT.Where(n => n.DEPT_CODE == id).FirstOrDefaultAsync();
            if (dept != null)
            {
                _context.DEPARTMENT.Remove(dept);
                _context.SaveChangesAsync();
            }
            return dept;
        }

    }
}
