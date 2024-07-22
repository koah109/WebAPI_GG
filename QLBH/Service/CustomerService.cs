using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;

namespace QLBH.Service
{
    public class CustomerService:ICustomer
    {
        private readonly ApplicationDBContext _context;
        public CustomerService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetCustomer(int id)
        {

            return await _context.CUSTOMER.ToListAsync();
        }

        public async Task<Customer> DeleteCus(int id)
        {
            Customer cust = await _context.CUSTOMER.Where(n => n.CUST_CODE == id).FirstOrDefaultAsync();
            if (cust != null)
            {
                _context.CUSTOMER.Remove(cust);
                _context.SaveChangesAsync();
            }
            return cust;
        }

        public async Task<Customer> PostCust(CustomerDTO request)
        {

            var cust = new Customer
            {
                EMAIL = request.email,
                CUST_NAME = request.searchValue,
                PHONE = request.phone,
                ADDRESS = request.address,
                UPDATER = "Admin",
                UPDATE_DATE = DateTime.Now,
            };

            _context.CUSTOMER.Add(cust);
            await _context.SaveChangesAsync();
            return cust;
        }
    }
}
