using Microsoft.EntityFrameworkCore;
using QLBH.AutoMapper;
using QLBH.Models;
using QLBH.Models.Entities;

namespace QLBH.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Customer> CUSTOMER { get; set; }

        public DbSet<Employee> EMPLOYEE { get; set; }

        public DbSet<Orders> ORDERS { get; set; }

        public DbSet<ORDER_DETAILS> ORDER_DETAILS{ get; set; }

        public DbSet<Product> PRODUCT { get; set; }

        public DbSet<Warehouse> WAREHOUSE { get; set; } 

        public DbSet<Department> DEPARTMENT { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ADMIN;Database=MyDB;Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=True");
            
        }
        




    }
}
