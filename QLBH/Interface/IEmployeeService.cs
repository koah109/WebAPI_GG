using QLBH.DTO;
using QLBH.Models;

namespace QLBH.Interface
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployee(int id);

        Task<Employee> PostEmployee(EmployeeRequest request);

        Task<Employee> UpdateEmployee(Employee request);

        Task<Employee> DeleteEmployee(int id);
    }
}
