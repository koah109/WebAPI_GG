using AutoMapper;
using Azure.Messaging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLBH.Data;
using QLBH.DTO;
using QLBH.Interface;
using QLBH.Models;
using QLBH.Models.Response;
using System.Diagnostics.Eventing.Reader;
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

            foreach (var detail in request.OrderDetails)
             {
                var prod =  _context.PRODUCT.FirstOrDefault(x=>x.PROD_CODE == detail.PROD_CODE);
                 //Cập nhật số lượng tồn kho
                 prod.STOCK_QTY -= detail.QUANTITY;
                 _context.PRODUCT.Update(prod);
             }
                  await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Orders> ChangeOrder(int id, OrderRequest request)
        {
            var existingOrder = await _context.ORDERS
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.ORDER_NO == id);
            // Sao chép các thuộc tính không phải là khóa chính từ request sang đơn hàng hiện tại
            _context.Entry(existingOrder).CurrentValues.SetValues(request);
            // Đảm bảo thuộc tính ORDER_NO không bị thay đổi
            _context.Entry(existingOrder).Property(o => o.ORDER_NO).IsModified = false;
            // Danh sách các chi tiết đơn hàng hiện tại
            var existingOrderDetails = existingOrder.OrderDetails.ToList();
            // Xử lý các chi tiết đơn hàng mới
            foreach (var detail in request.OrderDetails)
            {
                var existingDetail = existingOrderDetails
                    .FirstOrDefault(d => d.SO_ROW_NO == detail.SO_ROW_NO);

                if (existingDetail != null)
                {
                    // Cập nhật các chi tiết đơn hàng hiện tại
                    _context.Entry(existingDetail).CurrentValues.SetValues(detail);
                }
                else
                {
                    // Thêm mới các chi tiết đơn hàng
                    var newDetail = _mapper.Map<ORDER_DETAILS>(detail);
                    existingOrder.OrderDetails.Add(newDetail);
                }
            }
            // Xóa các chi tiết đơn hàng không còn tồn tại trong đơn hàng mới
            foreach (var detail in existingOrderDetails)
            {
                if (!request.OrderDetails.Any(d => d.SO_ROW_NO == detail.SO_ROW_NO))
                {
                    _context.ORDER_DETAILS.Remove(detail);
                }
            }

            // Lưu các thay đổi cuối cùng
            await _context.SaveChangesAsync();

            return existingOrder;


        }


        public async Task<List<Orders>> GetOrderById(int id)
        {
            return await _context.ORDERS.ToListAsync();
        }

        public async Task<OrderRequest> GetDetailOrder(int id)
        {
            var order = await _context.ORDERS
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.ORDER_NO == id);
            if (order == null)
            {
                throw new Exception("Không tìm thấy đơn hàng");
            }
            //var orderRequest = _mapper.Map<OrderRequest>(order);
            var orderRequest = new OrderRequest
            {
                DEPT_CODE = order.DEPT_CODE,
                CUST_CODE = order.CUST_CODE,
                EMP_CODE = order.EMP_CODE,
                WH_CODE = order.WH_CODE,
                CMP_TAX = order.CMP_TAX,
                SLIP_COMMENT = order.SLIP_COMMENT,
                OrderDetails = order.OrderDetails.Select(d => new OrderDetailRequest
                {
                    PROD_CODE = d.PROD_CODE,
                    UNITPRICE = d.UNITPRICE,
                    QUANTITY = d.QUANTITY,
                    CMP_TAX_RATE = d.CMP_TAX_RATE,
                    RESERVE_QTY = d.RESERVE_QTY,
                    DELIVERY_ORDER_QTY = d.DELIVERY_ORDER_QTY,
                    DELIVERED_QTY = d.DELIVERED_QTY,
                    COMPLETE_FLG = d.COMPLETE_FLG,
                    DISCOUNT = d.DISCOUNT
                }).ToList()
            };
            return orderRequest;
        }


        public async  Task<Orders> DeleteOrderById(int id)
        {
            var order = await _context.ORDERS.FindAsync(id);
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
