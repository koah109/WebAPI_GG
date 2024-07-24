using QLBH.Models.Entities;
using QLBH.Models.Request;

namespace QLBH.Interface
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetDepartmentById(int id);

        Task<Department> PostDepartment(DepartmentRequest request);

        Task<Department> DeleteDepartment(int id);
    }
}
