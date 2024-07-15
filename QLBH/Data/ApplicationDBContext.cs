using Microsoft.EntityFrameworkCore;
using QLBH.Models;

namespace QLBH.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext>options): base(options) { }

        public DbSet<Customer> Customer{ get; set; }

        public DbSet<Account>   Accounts{ get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Orders>   Orders { get; set; }

        public DbSet<Order_Detail> order_Detail { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Bill> Bills    { get; set; }
    }
}
