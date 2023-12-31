﻿using AutoMapper.Configuration.Conventions;
using JobTracker.Domain.Entities;
using JobTracker.Services;

namespace JobTracker.Data_Access.Repositories
{
    public interface IJobApplicationRepository
    {
        Task<IEnumerable<JobApplication>> GetJobApplicationsAsync();
        Task<(IEnumerable<JobApplication>, PaginationMetadata)> GetJobApplicationsAsync(bool includeJob, int pageNumber, int pageSize);
        Task<JobApplication?> GetJobApplicationAsync(int applicationId);
        Task<JobApplication?> GetJobApplicationAsync(int applicationId, bool includeJob);
        Task<bool> AddJobApplicationAsync(JobApplication application);
        Task<bool> DeleteJobApplicationAsync(JobApplication application);
        Task SaveChangesAsync();
    }
}
