using QLBH.DTO;
using QLBH.Models;
using QLBH.Service;

namespace QLBH.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetList(ProductRequest request);


        Task<List<Product>> GetProd(int id);

        Task<Product> PostProdById(ProductRequest request);

        Task<Product> PutProductById(Product response);

        Task<Product> DeleteProductById(int id);
        
    }
}
