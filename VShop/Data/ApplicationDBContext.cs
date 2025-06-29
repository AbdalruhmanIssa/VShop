using Microsoft.EntityFrameworkCore;
using VShop.Models;

namespace VShop.Data
{
    public class ApplicationDBContext:DbContext
    {
       public DbSet<Category> Categories { get; set; }
       public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=.;Database=VShop;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="Mobiles"},
                new Category { Id=2,Name="Tablets"},
                new Category { Id=3,Name="Laptops"},
                new Category { Id=4,Name="PC"},
                new Category { Id=5,Name="AirPods"}
                );



                
        }
    }
}
