using AutoMapper.Configuration.Conventions;
using JobTracker.Domain.Entities;

namespace JobTracker.Data_Access.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<IEnumerable<Company>> GetCompaniesAsync(bool includeJobs);
        Task<Company?> GetCompanyAsync(int companyId);
        Task<Company?> GetCompanyAsync(int companyId, bool includeJob);
        Task<bool> AddCompanyAsync(Company company);
        Task<bool> DeleteCompanyAsync(Company company);
    }
}
