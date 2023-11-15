using JobTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace JobTracker.Domain.DbContexts
{
    public class JobTrackerContext : DbContext
    {
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Interview> Interviews { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }

        public JobTrackerContext(DbContextOptions<JobTrackerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = 1,
                    Name = "Test Company",
                    Description = "Test Description",
                    Industry = "Test Industry",
                });

            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = 1,
                    JobTitle = "Test Job",
                    CompanyId = 1
                });

            modelBuilder.Entity<Company>().OwnsOne(c => c.Location).HasData(
                new { CompanyId = 1, City = "Test City", Country = "UK" });

            modelBuilder.Entity<Job>().OwnsOne(j => j.Location).HasData(
                new { JobId = 1, City = "Test City", Country = "UK" });

            modelBuilder.Entity<Job>().OwnsOne(j => j.Salary).HasData(
                new { JobId = 1, Amount = 20.0M, Currency = Currency.GBP });

            modelBuilder.Entity<JobApplication>().HasData(
                new JobApplication
                {
                    Id = 1,
                    JobId = 1,
                    InitialDateAdvertised = DateTime.Now.AddDays(-5),
                    InitialApplicationDate = DateTime.Now,
                    Deadline = DateTime.Now.AddDays(5),
                    Status = ApplicationStatus.Applied
                });

            new JobApplicationEntityTypeConfiguration().Configure(modelBuilder.Entity<JobApplication>());
            new JobEntityTypeConfiguration().Configure(modelBuilder.Entity<Job>());
            new CompanyEntityTypeConfiguration().Configure(modelBuilder.Entity<Company>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
