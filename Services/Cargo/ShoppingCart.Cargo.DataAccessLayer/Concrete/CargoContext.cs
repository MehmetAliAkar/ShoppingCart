using Microsoft.EntityFrameworkCore;
using ShoppingCart.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Cargo.DataAccessLayer.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=127.0.0.1,1431;Initial Catalog=ShoppingCartCargoDb;Application Name=ShoppingCartCargoDb;User Id=sa;Password=test123*;TrustServerCertificate=true;");
        }
        public DbSet<CargoCompany> CargoCompanies{ get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
