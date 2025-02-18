using Microsoft.EntityFrameworkCore;

namespace AuthServiceApi.Models
{
    public class AuthDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
