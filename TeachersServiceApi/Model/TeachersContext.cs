using Microsoft.EntityFrameworkCore;

namespace TeachersServiceApi.Model
{
    public class TeachersContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public TeachersContext(DbContextOptions<TeachersContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher() { Id = 1, Name = "Bob", Email = "email3@mail.com", Department = "IT", PhoneNumber = "123456890" },
                new Teacher() { Id = 2, Name = "Mike", Email = "email4@mail.com", Department = "Management", PhoneNumber = "012345689" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
