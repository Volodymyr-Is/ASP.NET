using Microsoft.EntityFrameworkCore;

namespace CoursesServiceApi.Model
{
    public class CourseContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, Name = "course1", Description = "course1 description", Credits = 100, Department = "IT" },
                new Course() { Id = 2, Name = "course2", Description = "course2 description", Credits = 120, Department = "Management" }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}
