using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Models;
using QLBH.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
namespace QLBH.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;

        public ProductService(ApplicationDBContext context)
        {
            _context = context;

        }

        public async Task<List<Product>> GetProdByName(ProductRequest request)
        {
            var prod = _context.PRODUCT.AsQueryable();
            if (request.PROD_NAME != null)
            {
                prod = prod.Where(predicate: n => n.PROD_NAME.Contains(request.PROD_NAME));
            }
            return await prod.ToListAsync();
            //var data = await prod.ToListAsync();
            //return data;
        }

        public async Task<List<Product>> GetProd(int id)
        {
            return await _context.PRODUCT.ToListAsync();
        }


        public async Task<Product> PostProdById(ProductRequest request)
        {
            var order = new Product
            {
                PROD_NAME = request.PROD_NAME,
                STOCK_QTY = request.STOCK_QTY,
                UNITPRICE = request.UNITPRICE,
                WH_CODE = request.WH_CODE,
                UPDATER = "ADMIN",
                UPDATE_DATE = DateTime.Now,
            };

            _context.PRODUCT.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public Task<Product> PutProductById(Product request)
        {
            _context.Entry(request).State = EntityState.Modified;
            _context.SaveChanges();
            return  Task.FromResult(request);

        }


        public async Task<Product> DeleteProductById(int id)
        {
            Product product = await _context.PRODUCT.Where(n => n.PROD_CODE == id).FirstOrDefaultAsync();
            if (product != null)
            {
                _context.PRODUCT.Remove(product);
                Task<int> task = _context.SaveChangesAsync();
            }
            return product;
        }
    }
}
