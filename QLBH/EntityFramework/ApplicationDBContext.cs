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
            optionsBuilder.UseSqlServer("Server=ADMIN;Database=NewDB;Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=True");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cấu hình khóa ngoại từ Warehouse đến Product
            modelBuilder.Entity<Warehouse>()
                .HasMany(p => p.Product)
                .WithOne(c => c.Warehouse)
                .HasForeignKey(c => c.WH_CODE)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Cấu hình khóa ngoại từ ORDER_DETAILS đến Orders
            modelBuilder.Entity<Orders>()
                .HasMany(p => p.OrderDetails)
                .WithOne(c => c.Orders)
                .HasForeignKey(c => c.ORDER_NO)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Cấu hình khóa ngoại từ ORDER_DETAILS đến Product
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Orderdetails)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.PROD_CODE)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Cấu hình khóa ngoại từ Orders đến Customer
            modelBuilder.Entity<Customer>()
                .HasMany(p => p.Orders)
                .WithOne(c => c.Customer)
                .HasForeignKey(c => c.CUST_CODE)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Cấu hình khóa ngoại từ Orders đến Warehouse
            modelBuilder.Entity<Warehouse>()
                .HasMany(p => p.Orders)
                .WithOne(c => c.Warehouse)
                .HasForeignKey(c => c.WH_CODE)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Cấu hình khóa ngoại từ Orders đến Employee
            modelBuilder.Entity<Employee>()
                .HasMany(p => p.Orders)
                .WithOne(c => c.Employee)
                .HasForeignKey(c => c.EMP_CODE)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

            //Cấu hình khóa ngoại từ Orders đến Department
            modelBuilder.Entity<Department>()
                .HasMany(p => p.Orders)
                .WithOne(c => c.Department)
                .HasForeignKey(c => c.DEPT_CODE)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);

        }







    }
}
