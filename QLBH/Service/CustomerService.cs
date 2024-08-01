using AutoMapper;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;

namespace QLBH.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public CustomerService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Customer>> GetCustomer(int id)
        {

            return await _context.CUSTOMER.ToListAsync();
        }


        //public async Task<Customer> PatchCustomer(int id, CustomerRequest request)
        //{
        //    //var customer = await _context.CUSTOMER.FindAsync(id);
        //    var cust = _mapper.Map<Customer>(request);
        //    _context.CUSTOMER.Add(cust);
        //    await _context.SaveChangesAsync();
        //    _context.CUSTOMER.Update(cust);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        throw new Exception("Cập nhật thông tin lỗi", ex);
        //    }
        //    return cust;
        //}


        public async Task<Customer> DeleteCus(int id)
        {
            
            var cust = await _context.CUSTOMER.Where(n => n.CUST_CODE == id).FirstOrDefaultAsync();
            if (cust == null)
            {
                throw new Exception("Không có khách hàng để xóa");
            }
            _context.CUSTOMER.Remove(cust);
            await _context.SaveChangesAsync();
            return cust;

        }

        public async Task<Customer> PostCust(CustomerRequest request)
        {

            var cust = _mapper.Map<Customer>(request);
            _context.CUSTOMER.Add(cust);
            await _context.SaveChangesAsync();
            return cust;
        }


        public async Task<Customer> PutCust(Customer request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;
        }
    }
}
