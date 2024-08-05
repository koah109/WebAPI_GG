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

        public async Task<List<Customer>> GetCustomer()
        {

            return await _context.CUSTOMER.ToListAsync();
        }

        public async Task<Customer> DeleteCus(int id)
        {
            var cust = await _context.CUSTOMER.FindAsync(id);
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


        public async Task<Customer> PutCust(int id,CustomerRequest request)
        {
            var customer = await _context.CUSTOMER.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("Không có khách hàng để thay đổi");
            }

            //Kiểm tra trường nào có sự thay đổi để update
            if (!string.IsNullOrEmpty(request.CUST_NAME) && request.CUST_NAME != customer.CUST_NAME)
            {
                customer.CUST_NAME = request.CUST_NAME;
            }
            if (!string.IsNullOrEmpty(request.ADDRESS) && request.ADDRESS != customer.ADDRESS)
            {
                customer.ADDRESS = request.ADDRESS;
            }
            if (!string.IsNullOrEmpty(request.PHONE) && request.PHONE != customer.PHONE)
            {
                customer.PHONE = request.PHONE;
            }
            
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
