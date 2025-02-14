using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace StudentsServiceApi.Model
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student() { Id = 1, Name = "John", Email = "email1@mail.com", DateOfBirth = DateTime.UtcNow, Address = "address1", PhoneNumber = "012345689" },
                new Student() { Id = 2, Name = "Alice", Email = "email2@mail.com", DateOfBirth = DateTime.UtcNow, Address = "address2", PhoneNumber = "123456890" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
