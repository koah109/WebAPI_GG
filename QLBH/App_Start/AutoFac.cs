using QLBH.Data;
using QLBH.Interface;
using QLBH.Service;
using Microsoft.EntityFrameworkCore;

namespace QLBH.App_Start
{
    public static class AutoFac
    {
        public static void Res(IServiceCollection builder)
        {
            //builder.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder..GetConnectionString("DefaultConnection")));
            //builder.AddScoped<IProduct, ProductService>();
        }
    }
}
