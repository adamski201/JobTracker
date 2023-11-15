using JobTracker.Domain.Entities;

namespace JobTracker.Data_Access.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompaniesAsync();
        Task<IEnumerable<Company>> GetCompaniesAsync(bool includeJobs);
        
    }
}
