using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyShop.Discount.Entities;
using System.Data;

namespace MyShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        IConfiguration _configuration;
        string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=CEMRE\SQLEXPRESS;Initial Catalog = DiscountDb;Integrated Security=true;TrustServerCertificate=True;");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
