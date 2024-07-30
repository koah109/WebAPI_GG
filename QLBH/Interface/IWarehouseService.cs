using Microsoft.AspNetCore.Mvc;
using QLBH.Models.Entities;
using QLBH.Models.Request;

namespace QLBH.Interface
{
    public interface IWarehouseService
    {
        Task<List<Warehouse>> GetWHById(int id);

        Task<Warehouse> PostWH(WarehouseRequest request);

        Task<Warehouse> DeleteWH(int id);
    }
}
