using System.Reflection;
using Microsoft.EntityFrameworkCore;
using OrderingShop.Infrastructure.Context.Entities;

namespace OrderingShop.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}

