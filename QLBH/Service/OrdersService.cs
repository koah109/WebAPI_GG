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
    public class OrdersService: IOrders
    {
        private readonly ApplicationDBContext _context;
        public OrdersService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<ORDER_DETAILS> PostOrders(OrderDTO request)
        {


            var order = new ORDER_DETAILS
            {
                SO_ROW_NO = request.SO_ROW_NO,
                PROD_NAME = request.PROD_NAME,
                QUANTITY = request.QUANTITY,
                UNITPRICE = request.PRICE * (float)request.QUANTITY,
                
                DELIVERY_DATE = DateTime.Now,
                UPDATE_DATE = DateTime.Now,
            };
            
            _context.ORDER_DETAILS.Add(order);
            await _context.SaveChangesAsync();
            return order;

        }

        public async Task<List<ORDER_DETAILS>> GetOrderById(int id)
        {
            return await _context.ORDER_DETAILS.ToListAsync();
        }

        public async  Task<ORDER_DETAILS> DeleteOrderById(int id)
        {
            ORDER_DETAILS orders = await _context.ORDER_DETAILS.Where(n => n.SO_ROW_NO == id).FirstOrDefaultAsync();

            if (orders != null)
            {
                _context.ORDER_DETAILS.Remove(orders);
                await _context.SaveChangesAsync();
            }

            return orders;

        }
    }
}
