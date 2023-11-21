using JobTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace JobTracker.Domain.DbContexts
{
    public class JobTrackerContext : DbContext
    {
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public JobTrackerContext(DbContextOptions<JobTrackerContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new JobApplicationEntityTypeConfiguration().Configure(modelBuilder.Entity<JobApplication>());
            new JobEntityTypeConfiguration().Configure(modelBuilder.Entity<Job>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
