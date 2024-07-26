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

            CreateMap<Orders, OrderRequest>()
                .ForMember(dest => dest.DEPT_CODE, opt => opt.MapFrom(src => src.DEPT_CODE))
                .ForMember(dest => dest.CUST_CODE, opt => opt.MapFrom(src => src.CUST_CODE))
                .ForMember(dest => dest.WH_CODE, opt => opt.MapFrom(src => src.WH_CODE))
                .ForMember(dest => dest.CMP_TAX, opt => opt.MapFrom(src => src.CMP_TAX))
                .ForMember(dest => dest.SLIP_COMMENT, opt => opt.MapFrom(src => src.SLIP_COMMENT));

            CreateMap<Product, ProductRequest>()
                .ForMember(dest => dest.PROD_NAME, opt => opt.MapFrom(src => src.PROD_NAME))
                .ForMember(dest => dest.UNITPRICE, opt => opt.MapFrom(src => src.UNITPRICE))
                .ForMember(dest => dest.STOCK_QTY, opt => opt.MapFrom(src => src.STOCK_QTY))
                .ForMember(dest => dest.WH_CODE, opt => opt.MapFrom(src => src.WH_CODE));


            CreateMap<Customer, CustomerRequest>()
                .ForMember(dest => dest.CUST_NAME, opt => opt.MapFrom(src => src.CUST_NAME))
                .ForMember(dest => dest.ADDRESS, opt => opt.MapFrom(src => src.ADDRESS))
                .ForMember(dest => dest.EMAIL, opt => opt.MapFrom(src => src.EMAIL))
                .ForMember(dest => dest.PHONE, opt => opt.MapFrom(src => src.PHONE));


            CreateMap<Employee, EmployeeRequest>()
                .ForMember(dest => dest.EMP_NAME, opt => opt.MapFrom(src => src.EMP_NAME))
                .ForMember(dest => dest.POSITION, opt => opt.MapFrom(src => src.POSITION));


            CreateMap<Department, DepartmentRequest>()
                .ForMember(dest => dest.DEPT_NAME, opt => opt.MapFrom(src => src.DEPT_NAME))
                .ForMember(dest => dest.ADDRESS, opt => opt.MapFrom(src => src.ADDRESS));




        }
    }
}
