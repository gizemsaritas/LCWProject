using LCWProject.DataAccess.TypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LCWProject.DataAccess.Concrete.Context
{
    public class DemoDbContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public DemoDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("db"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductTypeConfiguration());
        }
    }
}
