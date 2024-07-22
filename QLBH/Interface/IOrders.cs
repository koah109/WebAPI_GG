using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Interface
{
    public interface IOrders
    {
        Task<ORDER_DETAILS> PostOrders(OrderDTO request);

        Task<List<ORDER_DETAILS>> GetOrderById(int id);

        Task<ORDER_DETAILS> DeleteOrderById(int id);
    }
}
