using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dz_30._01.Models
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) {
            Database.EnsureCreated();
        }
    }
}
