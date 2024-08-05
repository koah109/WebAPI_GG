using QLBH.Data;
using QLBH.Interface;
using QLBH.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;


namespace QLBH.App_Start
{
    public static class AutoFac
    {
        public static void Res(IServiceCollection builder, IConfiguration configuration)
        {
            builder.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.AddScoped<IProductService, ProductService>();
            builder.AddScoped<IOrdersService, OrdersService>();
            builder.AddScoped<ICustomerService, CustomerService>();
            builder.AddScoped<IEmployeeService, EmployeeService>();
            builder.AddScoped<IDepartmentService, DepartmentService>();
            builder.AddScoped<IWarehouseService, WarehouseService>();
            builder.AddScoped<IReport, ReportService>();
            
        }
    }
}
