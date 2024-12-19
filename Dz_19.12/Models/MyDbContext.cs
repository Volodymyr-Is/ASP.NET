using Microsoft.EntityFrameworkCore;

namespace Dz_19._12.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
