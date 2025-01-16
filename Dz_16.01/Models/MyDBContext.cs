using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dz_16._01.Models
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options) { }

        public DbSet<ErrorLogger> ErrorLoggers { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
