using Microsoft.EntityFrameworkCore;
using ShoppingCart.Order.Domain.Entities;

namespace ShoppingCart.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1431;Initial Catalog=ShoppingCartOrderDb;Application Name=ShoppingCartOrderDb;User Id=sa;Password=test123*;TrustServerCertificate=true;");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}