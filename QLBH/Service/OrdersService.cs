using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using System.Reflection.Metadata.Ecma335;

namespace QLBH.Service
{
    public class OrdersService: IOrdersService
    {
        private readonly ApplicationDBContext _context;
        public OrdersService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ORDER_DETAILS> PostOrders(OrderRequest request)
        {
            
            var order_detail = new OrderDetailRequest();
            var order = new ORDER_DETAILS
            {
                PROD_CODE = order_detail.PROD_CODE,

                
                DELIVERY_DATE = DateTime.Now,
                UPDATE_DATE = DateTime.Now,
            };

            _context.ORDER_DETAILS.Add(order);
            await _context.SaveChangesAsync();
            return order;

        }

        public async Task<List<Orders>> GetOrderById(int id)
        {
            return await _context.ORDERS.ToListAsync();
        }

        public async  Task<Orders> DeleteOrderById(int id)
        {
            Orders orders = await _context.ORDERS.Where(n => n.ORDER_NO == id).FirstOrDefaultAsync();

            if (orders != null)
            {
                _context.ORDERS.Remove(orders);
                await _context.SaveChangesAsync();
            }

            return orders;

        }
    }
}
