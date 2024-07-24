using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Interface
{
    public interface IOrdersService
    {
        Task<ORDER_DETAILS> PostOrders(OrderRequest request);

        Task<List<Orders>> GetOrderById(int id);

        Task<Orders> DeleteOrderById(int id);
    }
}
