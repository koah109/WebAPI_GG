using AutoMapper;
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
        private readonly IMapper _mapper;
        public OrdersService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Orders> PostOrders(OrderRequest request)
        {

            var order = _mapper.Map<Orders>(request);

            _context.ORDERS.Add(order);
            _context.SaveChanges();

           /* foreach (var detail in request.OrderDetails)
            {
                var prod = await _context.PRODUCT
                .Where(p => p.PROD_CODE == detail.PROD_CODE)
                .FirstOrDefaultAsync();

                var orderDetail = _mapper.Map<ORDER_DETAILS>(prod);
                orderDetail.ORDER_NO = order.ORDER_NO; // Ánh xạ khóa ngoại
                orderDetail.QUANTITY = detail.QUANTITY; // Ánh xạ số lượng từ detail
                _context.ORDER_DETAILS.Add(orderDetail);
           /
                Cập nhật số lượng tồn kho
                prod.STOCK_QTY -= detail.QUANTITY;
                _context.PRODUCT.Update(prod);
            }
                 await _context.SaveChangesAsync();*/
                 return order;
               
        }

        public async Task<List<Orders>> GetOrderById(int id)
        {
            return await _context.ORDERS.ToListAsync();
        }


        public async  Task<Orders> DeleteOrderById(int id)
        {
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
