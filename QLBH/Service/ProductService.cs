using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Models;
using QLBH.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
namespace QLBH.Service
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public ProductService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetProdByName(ProductRequest request)
        {
            var prod = _context.PRODUCT.AsQueryable();
            if (request.PROD_NAME != null)
            {
                prod = prod.Where(predicate: n => n.PROD_NAME.Contains(request.PROD_NAME));
            }
            return await prod.ToListAsync();         
        }

        public async Task<List<Product>> GetProd()
        {
            return await _context.PRODUCT.ToListAsync();
        }


        public async Task<Product> PostProdById(ProductRequest request)
        {
            var order = _mapper.Map<Product>(request); 

            _context.PRODUCT.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Product> PutProductById(Product request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;

        }


        public async Task<Product> DeleteProductById(int id)
        {
            Product product = await _context.PRODUCT.FindAsync(id);
            if (product == null)
            {
                throw new Exception("Không có sản phẩm để xóa");
            }
            _context.PRODUCT.Remove(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}
