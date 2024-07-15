using QLBH.DTO;
using QLBH.Models;
using QLBH.Service;

namespace QLBH.Interface
{
    public interface IProduct
    {
        Task<List<Product>> getList(ProductDTO request);


        Task<List<Product>> getProd(Product product);
    }
}
