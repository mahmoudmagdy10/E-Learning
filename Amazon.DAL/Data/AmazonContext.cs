using Amazon.DAL.Entity;
using ConsoleApp1.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Amazon.DAL.Data
{
    public class AmazonContext : IdentityDbContext<IdentityUser>
    {

        public AmazonContext(DbContextOptions<AmazonContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brands>().HasKey(a => a.Id);
            modelBuilder.Entity<Categories>().HasKey(a => a.Id);
            modelBuilder.Entity<Products>().HasKey(a => a.Id);
            modelBuilder.Entity<Images>().HasKey(a => a.Id);
            modelBuilder.Entity<Cart>().HasKey(a => a.Id);
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProduct { get; set; }
    }
}
