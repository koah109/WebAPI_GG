using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using System.Buffers;

namespace QLBH.Service
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public EmployeeService(ApplicationDBContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<List<Employee>> GetEmployee(int id)
        {
            return await _context.EMPLOYEE.ToListAsync();
        }


        public async Task<Employee> PostEmployee([FromBody]EmployeeRequest request)
        {
            var emp = _mapper.Map<Employee>(request);

            _context.EMPLOYEE.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async  Task<Employee> UpdateEmployee(Employee request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;
        }


        public async Task<Employee> DeleteEmployee(int id)
        {

            Employee emp = await _context.EMPLOYEE.FindAsync(id);
            if (emp == null)
            {
                throw new Exception("Không có nhân viên để xóa");
            }
            _context.EMPLOYEE.Remove(emp);
            await _context.SaveChangesAsync();
            return emp;
        }
    }
}
