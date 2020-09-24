using Microsoft.EntityFrameworkCore;
using RecruitmentTask.Core.Configuration;
using RecruitmentTask.Core.Entities;

namespace RecruitmentTask.Core
{
    public class RecruitmentTaskContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public RecruitmentTaskContext(DbContextOptions<RecruitmentTaskContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.Entity<Employee>().HasOne(i => i.Company).WithMany(c => c.Employees).OnDelete(DeleteBehavior.Cascade);
        }


    }
}
