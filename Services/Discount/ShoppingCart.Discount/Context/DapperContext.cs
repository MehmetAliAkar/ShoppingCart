using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Discount.Entities;
using System.Data;

namespace ShoppingCart.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1431;Initial Catalog=ShoppingCartDiscountDb;Application Name=ShoppingCartDiscountDb;User Id=sa;Password=test123*;TrustServerCertificate=true;",
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
        }

        public DbSet<Coupon> Coupons { get; set; }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}