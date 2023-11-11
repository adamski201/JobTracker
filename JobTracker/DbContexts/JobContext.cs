using JobTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.DbContexts
{
    public class JobContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }

        public JobContext(DbContextOptions<JobContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    EmployerName = "TestEmployer",
                    JobTitle = "TestTitle",
                    City = "TestCity",
                    Salary = 10.0f,
                    Description = "This is a test job.",
                    ApplicationDate = DateTime.Now,
                    Status = JobStatus.Success
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
