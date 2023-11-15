using JobTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracker.Domain.DbContexts
{
    public class JobEntityTypeConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> jobConfiguration)
        {
            jobConfiguration.OwnsOne(j => j.Salary);
            jobConfiguration.OwnsOne(j => j.Location);
        }
    }
}
