using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomer(int id);

        Task<Customer> DeleteCus(int id);

        Task<Customer> PostCust(CustomerRequest request);

        Task<Customer> PutCust(Customer request);
    }
}
