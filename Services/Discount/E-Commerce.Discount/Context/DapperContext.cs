using E_Commerce.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace E_Commerce.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;

            //dapper context sınıfı ayağa kalktığında
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
   
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=SEMIH\\SQLEXPRESS;inital catalog=E-CommerceDiscountDb;integrated Security=true;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("Server=SEMIH\\SQLEXPRESS;Initial Catalog=E-CommerceDiscountDb;Integrated Security=True;TrustServerCertificate=True;");

        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

    }
}
