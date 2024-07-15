using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Models;
using QLBH.Interface;
namespace QLBH.Service
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDBContext _context;

        public ProductService(ApplicationDBContext context)
        {
            _context = context;

        }

        public async Task<List<Product>> getList(ProductDTO request)
        {
            var prod = _context.Product.AsQueryable();
            if (request.SEARCHVALUE != null)
            {
                prod = prod.Where(n => n.PROD_NAME.Contains(request.SEARCHVALUE));
            }
            return await prod.ToListAsync();
            //var data = await prod.ToListAsync();
            //return data;
        }

        public async Task<List<Product>> getProd(Product product)
        {
            return await _context.Product.ToListAsync();
        }
    }
}
