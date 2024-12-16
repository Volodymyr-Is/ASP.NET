using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dz_16._12.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<InfoModel> PersonalInfos { get; set; }
        public DbSet<SkillsModel> Skills { get; set; }
        public DbSet<TestQuestionModel> TestResults { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }
        public MyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Dz_16_12;Trusted_Connection=True;");
            }
        }
    }
}
