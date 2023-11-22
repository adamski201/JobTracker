using JobTracker.Domain.DbContexts;
using JobTracker.Domain.Entities;
using JobTracker.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace JobTracker.Data_Access.Repositories
{
    public class JobApplicationRepository : IJobApplicationRepository
    {
        private JobTrackerContext _context;

        public JobApplicationRepository(JobTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JobApplication>> GetJobApplicationsAsync()
        {
            return await _context.JobApplications.OrderBy(a => a.Job.JobTitle).ToListAsync();
        }

        public async Task<(IEnumerable<JobApplication>, PaginationMetadata)> GetJobApplicationsAsync(bool includeJob, int pageNumber = 1, int pageSize = 10)
        {
            var totalItemCount = await _context.JobApplications.CountAsync();
            PaginationMetadata paginationMetadata = new(totalItemCount, pageSize, pageNumber);

            if (includeJob)
            {
                var applicationsWithJobs = await _context.JobApplications
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Include(a => a.Job)
                    .ToListAsync();

                return (applicationsWithJobs, paginationMetadata);
            }

            var applications = await _context.JobApplications
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

            return (applications, paginationMetadata);
        }

        public async Task<JobApplication?> GetJobApplicationAsync(int applicationId)
        {
            return await _context.JobApplications.Where(a => a.Id == applicationId).FirstOrDefaultAsync();
        }

        public async Task<JobApplication?> GetJobApplicationAsync(int applicationId, bool includeJob)
        {
            if (includeJob)
            {
                return await _context.JobApplications.Where(a => a.Id == applicationId).Include(a => a.Job)
                    .FirstOrDefaultAsync();
            }

            return await GetJobApplicationAsync(applicationId);
        }

        public async Task<bool> AddJobApplicationAsync(JobApplication application)
        {
            _context.JobApplications.Add(application);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteJobApplicationAsync(JobApplication application)
        {
            _context.JobApplications.Remove(application);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
