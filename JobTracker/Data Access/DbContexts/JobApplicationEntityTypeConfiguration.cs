using JobTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobTracker.Domain.DbContexts
{
    public class JobApplicationEntityTypeConfiguration : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> jobApplicationConfiguration)
        {

        }
    }
}
