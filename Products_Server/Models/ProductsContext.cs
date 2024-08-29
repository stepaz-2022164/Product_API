using Microsoft.EntityFrameworkCore;

namespace Products_Server.Models
{
    public class ProductsContext : DbContext //Herencia
    {
        public ProductsContext(DbContextOptions<ProductsContext>options) : base(options) //Constructor
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasIndex(c => c.Name).IsUnique();
        }
    }
}
