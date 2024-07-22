using QLBH.DTO;
using QLBH.Models;
using QLBH.Service;

namespace QLBH.Interface
{
    public interface IProduct
    {
        Task<List<Product>> getList(ProductDTO request);


        Task<List<Product>> getProd(int id);

        Task<Product> PostProdById(ProductDTO request);

        Task<Product> PutProductById(Product response);

        Task<Product> DeleteProductById(int id);
        
    }
}
