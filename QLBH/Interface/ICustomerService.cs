using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Interface
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomer();

        Task<Customer> DeleteCus(int id);

        Task<Customer> PostCust(CustomerRequest request);

        Task<Customer> PutCust(int id, CustomerRequest request);


    }
}
