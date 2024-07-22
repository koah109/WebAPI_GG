using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Interface
{
    public interface ICustomer
    {
        Task<List<Customer>> GetCustomer(int id);

        Task<Customer> DeleteCus(int id);

        Task<Customer> PostCust(CustomerDTO request);
    }
}
