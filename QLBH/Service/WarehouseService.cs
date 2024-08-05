using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Models.Request;

namespace QLBH.Service
{
    public class WarehouseService : IWarehouseService

    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public WarehouseService(ApplicationDBContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        public async Task<List<Warehouse>> GetWHById(int id)
        {
            return await _context.WAREHOUSE.ToListAsync();
        }


        public async Task<Warehouse> PostWH([FromBody] WarehouseRequest request)
        {
            var wh = _mapper.Map<Warehouse>(request);

            _context.WAREHOUSE.Add(wh);
            await _context.SaveChangesAsync();
            return wh;
        }


        public async Task<Warehouse> DeleteWH(int id)
        {
            Warehouse wh = await _context.WAREHOUSE.FindAsync(id);
            if (wh == null)
            {
                throw new Exception("Không có nhân viên để xóa");
            }
            _context.WAREHOUSE.Remove(wh);
            await _context.SaveChangesAsync();
            return wh;
        }

        public async Task<Warehouse> UpdateWH(Warehouse request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;
        }



    }
}
