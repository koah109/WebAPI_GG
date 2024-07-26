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

        public async Task<ORDER_DETAILS> PostOrders(OrderDetailRequest drequest)
        {

            var order = new Orders
            {
                DEPT_CODE = 1,
                CUST_CODE = 6,
                EMP_CODE = 4,
                WH_CODE = 1,
                CMP_TAX = 15,
            };
            _context.ORDERS.Add(order);
            var prod = await _context.PRODUCT
                .Where(p => p.PROD_CODE == drequest.PROD_CODE)
                .FirstOrDefaultAsync();
            if (prod == null)
            {
                throw new Exception("Không có sản phẩm để order");
            }

            else    try
                {
                    await _context.SaveChangesAsync();
                    var ordersDetails = new ORDER_DETAILS
                    {
                        PROD_CODE = drequest.PROD_CODE,
                        PROD_NAME = prod.PROD_NAME,
                        UNITPRICE = prod.UNITPRICE,
                        QUANTITY = drequest.QUANTITY,
                        CMP_TAX_RATE = order.CMP_TAX,
                        RESERVE_QTY = prod.STOCK_QTY - drequest.QUANTITY,
                        DELIVERED_QTY = drequest.QUANTITY,
                        DELIVERY_ORDER_QTY = drequest.QUANTITY,
                        UPDATER = "Admin",
                        DELIVERY_DATE = DateTime.Now,
                        UPDATE_DATE = DateTime.Now,
                        ORDER_NO = order.ORDER_NO,
                    };
                    _context.ORDER_DETAILS.Add(ordersDetails);
                    prod.STOCK_QTY -= drequest.QUANTITY;
                    await _context.SaveChangesAsync();
                    return ordersDetails;
                }
                catch (DbUpdateException ex)
                {
                    throw new Exception("Có lỗi xảy ra khi lưu đơn hàng", ex);
                }
            
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
