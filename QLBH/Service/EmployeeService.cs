﻿using Microsoft.AspNetCore.Mvc;
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

        public EmployeeService(ApplicationDBContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Employee>> GetEmployee(int id)
        {
            return await _context.EMPLOYEE.ToListAsync();
        }


        public async Task<Employee> PostEmployee([FromBody]EmployeeRequest request)
        {
            var emp = new Employee
            {
                EMP_NAME = request.EMP_NAME,
                POSITION = request.POSITION,
                HIRE_DATE  = DateTime.Now,
                UPDATER = "Admin",
            };

            _context.EMPLOYEE.Add(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public  Task<Employee> UpdateEmployee(Employee request)
        {
            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(request);
        }


        public async Task<Employee> DeleteEmployee(int id)
        {

            Employee emp = await _context.EMPLOYEE.Where(n => n.EMP_CODE == id).FirstOrDefaultAsync();
            if (emp == null)
            {
                throw new Exception("Không có nhân viên để xóa");
            }
            _context.EMPLOYEE.Remove(emp);
            Task<int> task = _context.SaveChangesAsync();
            return emp;
        }
    }
}
