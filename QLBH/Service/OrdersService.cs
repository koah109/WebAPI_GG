using Azure.Messaging;
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

        public async Task<Orders> PostOrders(OrderRequest request)
        {

            var order = new Orders
            {
                DEPT_CODE = request.DEPT_CODE,
                CUST_CODE = request.CUST_CODE,
                EMP_CODE = request.EMP_CODE,
                WH_CODE = request.WH_CODE,
                CMP_TAX = request.CMP_TAX,
                SLIP_COMMENT = request.SLIP_COMMENT,
                
            };
            _context.ORDERS.Add(order);
            _context.SaveChanges();

            foreach (var detail in request.OrderDetails)
            {
                var prod = await _context.PRODUCT
                .Where(p => p.PROD_CODE == detail.PROD_CODE)
                .FirstOrDefaultAsync();
                var ordersDetails = new ORDER_DETAILS
                {

                    PROD_CODE = detail.PROD_CODE,
                    PROD_NAME = prod.PROD_NAME,
                    UNITPRICE = prod.UNITPRICE,
                    QUANTITY = detail.QUANTITY,
                    CMP_TAX_RATE = order.CMP_TAX,
                    RESERVE_QTY = prod.STOCK_QTY - detail.QUANTITY,
                    DELIVERED_QTY = detail.QUANTITY,
                    DELIVERY_ORDER_QTY = detail.QUANTITY,
                    UPDATER = "Admin",
                    DELIVERY_DATE = DateTime.Now,
                    UPDATE_DATE = DateTime.Now,
                    ORDER_NO = order.ORDER_NO,
                };
                _context.ORDER_DETAILS.Add(ordersDetails);
                prod.STOCK_QTY -= detail.QUANTITY;
                _context.PRODUCT.Update(prod);
            }
                 await _context.SaveChangesAsync();
                 return order;
               
        }

        public async Task<List<Orders>> GetOrderById(int id)
        {
            return await _context.ORDERS.ToListAsync();
        }


        public async  Task<Orders> DeleteOrderById(int id)
        {
            var orderDetails = await _context.ORDER_DETAILS
            .Where(od => od.ORDER_NO == id)
             .ToListAsync();
            _context.ORDER_DETAILS.RemoveRange(orderDetails);
            await _context.SaveChangesAsync();


            var order = await _context.ORDERS
            .Where(o => o.ORDER_NO == id)
            .FirstOrDefaultAsync();
            if(order == null)
            {
                throw new Exception("Không có order để xóa");
            }
            _context.ORDERS.Remove(order);
            await _context.SaveChangesAsync();
            
            return order;

        }

    }
}
