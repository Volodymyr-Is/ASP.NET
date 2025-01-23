using Microsoft.EntityFrameworkCore;

namespace Dz_23._01.Models
{
    //public class MyAppContext : DbContext
    //{
    //    public DbSet<Product> Products { get; set; }
    //    public DbSet<Category> Categories { get; set; }
    //    public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
    //    {
    //        Database.EnsureCreated();
    //    }
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Category>()
    //       .HasMany(c => c.Products)
    //       .WithOne(p => p.Category)
    //       .HasForeignKey(p => p.CategoryId);

    //        base.OnModelCreating(modelBuilder);
    //    }
    //}

    public class MyAppContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
