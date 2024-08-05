using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Interface
{
    public interface IOrdersService
    {
        Task<Orders> PostOrders(OrderRequest request);

        Task<List<Orders>> GetOrderById(int id);

        Task<OrderRequest> GetDetailOrder(int id);

        Task<Orders> DeleteOrderById(int id);

        Task<Orders> ChangeOrder(int id, OrderRequest request);
    }
}
