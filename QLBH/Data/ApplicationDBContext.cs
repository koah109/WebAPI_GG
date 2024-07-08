using Microsoft.EntityFrameworkCore;
using QLBH.Models;

namespace QLBH.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options): base(options) { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Orders>   Orders { get; set; }

        public DbSet<Order_Detail> order_Details { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}
