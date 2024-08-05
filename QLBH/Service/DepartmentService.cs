using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
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
        private readonly IMapper _mapper;
        public DepartmentService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Department>> GetDepartmentById(int id)
        {
            return await _context.DEPARTMENT.ToListAsync();
        }


        public async Task<Department> PostDepartment(DepartmentRequest request)
        {
            var dept = _mapper.Map<Department>(request);
            _context.DEPARTMENT.Add(dept);
            await _context.SaveChangesAsync();
            return dept;
        }

        public async Task<Department> DeleteDepartment(int id)
        {
            Department dept = await _context.DEPARTMENT.FindAsync(id);
            if (dept == null)
            {
                throw new Exception("Không có phòng ban để xóa");
            }
            _context.DEPARTMENT.Remove(dept);
            await _context.SaveChangesAsync();
            return dept;
        }

        public async Task<Department> UpdateDepartment(Department request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;
        }

    }
}
