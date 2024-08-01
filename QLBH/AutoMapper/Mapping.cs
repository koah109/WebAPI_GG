using AutoMapper;
using QLBH.DTO;
using QLBH.Models;
using QLBH.Models.Entities;
using QLBH.Models.Request;

namespace QLBH.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Product, ORDER_DETAILS>()
                .ForMember(dest => dest.RESERVE_QTY, opt => opt.MapFrom(src => src.STOCK_QTY))
                .ForMember(dest => dest.QUANTITY, opt => opt.Ignore());

            CreateMap<OrderRequest, Orders>()
                .ForMember(dest => dest.ORDER_DATE, opt => opt.MapFrom(src => DateTime.Now)) // ánh xạ ORDER_DATE thành thời gian hiện tại
                .ForMember(dest => dest.ORDER_NO, opt => opt.Ignore());


            CreateMap<ProductRequest, Product>();


            CreateMap<CustomerRequest, Customer>()
                .ForMember(dest => dest.UPDATE_DATE, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CUST_CODE, opt => opt.Ignore());


            CreateMap<EmployeeRequest, Employee>()
                .ForMember(dest => dest.HIRE_DATE, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.EMP_CODE, opt => opt.Ignore());


            CreateMap<DepartmentRequest, Department>()
                .ForMember(dest => dest.DEPT_CODE, opt => opt.Ignore());


            CreateMap<OrderDetailRequest, ORDER_DETAILS>()
                .ForMember(dest => dest.UPDATE_DATE, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.SO_ROW_NO, opt => opt.Ignore());

            CreateMap<WarehouseRequest, Warehouse>()
                .ForMember(dest => dest.WH_CODE, opt => opt.Ignore());


        }
    }
}
