using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Models;
using QLBH.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var prod = _context.PRODUCT.AsQueryable();
            if (request.PROD_NAME != null)
            {
                prod = prod.Where(n => n.PROD_NAME.Contains(request.PROD_NAME));
            }
            return await prod.ToListAsync();
            //var data = await prod.ToListAsync();
            //return data;
        }

        public async Task<List<Product>> getProd(int id)
        {
            return await _context.PRODUCT.ToListAsync();
        }


        public async Task<Product> PostProdById(ProductDTO request)
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

        public async Task<Product> PutProductById(Product response)
        {
            _context.Entry(response).State = EntityState.Modified;
            _context.SaveChanges();
            return  response;

        }


        public async Task<Product> DeleteProductById(int id)
        {
            Product product = _context.PRODUCT.FirstOrDefault(n => n.PROD_CODE == id);
            if (product != null)
            {
                _context.PRODUCT.Remove(product);
                _context.SaveChanges();
                return product;
            }
            else
            {
                return null;
            }
        }
    }
}
