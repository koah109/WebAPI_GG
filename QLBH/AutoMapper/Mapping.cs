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
                .ForMember(dest => dest.PROD_CODE, opt => opt.MapFrom(src => src.PROD_CODE))
                .ForMember(dest => dest.UNITPRICE, opt => opt.MapFrom(src => src.UNITPRICE))
                .ForMember(dest => dest.PROD_NAME, opt => opt.MapFrom(src => src.PROD_NAME))
                .ForMember(dest => dest.RESERVE_QTY, opt => opt.MapFrom(src => src.STOCK_QTY))
                .ForMember(dest => dest.QUANTITY, opt => opt.Ignore());

            CreateMap<OrderRequest, Orders>()
                .ForMember(dest => dest.DEPT_CODE, opt => opt.MapFrom(src => src.DEPT_CODE))
                .ForMember(dest => dest.EMP_CODE, opt => opt.MapFrom(src => src.EMP_CODE))
                .ForMember(dest => dest.CUST_CODE, opt => opt.MapFrom(src => src.CUST_CODE))
                .ForMember(dest => dest.WH_CODE, opt => opt.MapFrom(src => src.WH_CODE))
                .ForMember(dest => dest.CMP_TAX, opt => opt.MapFrom(src => src.CMP_TAX))
                .ForMember(dest => dest.SLIP_COMMENT, opt => opt.MapFrom(src => src.SLIP_COMMENT))
                .ForMember(dest => dest.ORDER_DATE, opt => opt.MapFrom(src => DateTime.Now)) // ánh xạ ORDER_DATE thành thời gian hiện tại
                .ForMember(dest => dest.ORDER_NO, opt => opt.Ignore());


            CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.PROD_NAME, opt => opt.MapFrom(src => src.PROD_NAME))
                .ForMember(dest => dest.UNITPRICE, opt => opt.MapFrom(src => src.UNITPRICE))
                .ForMember(dest => dest.STOCK_QTY, opt => opt.MapFrom(src => src.STOCK_QTY))
                .ForMember(dest => dest.WH_CODE, opt => opt.MapFrom(src => src.WH_CODE));


            CreateMap<CustomerRequest, Customer>()
                .ForMember(dest => dest.CUST_NAME, opt => opt.MapFrom(src => src.CUST_NAME))
                .ForMember(dest => dest.ADDRESS, opt => opt.MapFrom(src => src.ADDRESS))
                .ForMember(dest => dest.EMAIL, opt => opt.MapFrom(src => src.EMAIL))
                .ForMember(dest => dest.PHONE, opt => opt.MapFrom(src => src.PHONE))
                .ForMember(dest => dest.UPDATE_DATE, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CUST_CODE, opt => opt.Ignore());


            CreateMap<EmployeeRequest, Employee>()
                .ForMember(dest => dest.EMP_NAME, opt => opt.MapFrom(src => src.EMP_NAME))
                .ForMember(dest => dest.POSITION, opt => opt.MapFrom(src => src.POSITION))
                .ForMember(dest => dest.HIRE_DATE, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.EMP_CODE, opt => opt.Ignore());


            CreateMap<DepartmentRequest, Department>()
                .ForMember(dest => dest.DEPT_NAME, opt => opt.MapFrom(src => src.DEPT_NAME))
                .ForMember(dest => dest.ADDRESS, opt => opt.MapFrom(src => src.ADDRESS))
                .ForMember(dest => dest.DEPT_CODE, opt => opt.Ignore());


            CreateMap<OrderDetailRequest, ORDER_DETAILS>()
                .ForMember(dest => dest.PROD_CODE, opt => opt.MapFrom(src => src.PROD_CODE))
                .ForMember(dest => dest.UNITPRICE, opt => opt.MapFrom(src => src.UNITPRICE))
                .ForMember(dest => dest.DELIVERY_ORDER_QTY, opt => opt.MapFrom(src => src.DELIVERY_ORDER_QTY))
                .ForMember(dest => dest.RESERVE_QTY, opt => opt.MapFrom(src => src.RESERVE_QTY))
                .ForMember(dest => dest.DELIVERED_QTY, opt => opt.MapFrom(src => src.DELIVERED_QTY))
                .ForMember(dest => dest.CMP_TAX_RATE, opt => opt.MapFrom(src => src.CMP_TAX_RATE))
                .ForMember(dest => dest.COMPLETE_FLG, opt => opt.MapFrom(src => src.COMPLETE_FLG))
                .ForMember(dest => dest.DISCOUNT, opt => opt.MapFrom(src => src.DISCOUNT))
                .ForMember(dest => dest.QUANTITY, opt => opt.MapFrom(src => src.QUANTITY))
                .ForMember(dest => dest.UPDATE_DATE, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.SO_ROW_NO, opt => opt.Ignore());

            CreateMap<WarehouseRequest, Warehouse>()
                .ForMember(dest => dest.WH_CODE, opt => opt.Ignore());


        }
    }
}
