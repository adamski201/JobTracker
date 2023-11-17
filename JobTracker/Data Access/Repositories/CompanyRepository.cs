using JobTracker.Domain.DbContexts;
using JobTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobTracker.Data_Access.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private JobTrackerContext _context;

        public CompanyRepository(JobTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.OrderBy(c => c.Name).ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync(bool includeJobs)
        {
            if (includeJobs)
            {
                return await _context.Companies.Include(c => c.Jobs)
                    .OrderBy(c => c.Name).ToListAsync();
            }

            return await GetCompaniesAsync();
        }

        public async Task<Company?> GetCompanyAsync(int companyId)
        {
            return await _context.Companies.Where(c => c.Id == companyId).FirstOrDefaultAsync();
        }

        public async Task<Company?> GetCompanyAsync(int companyId, bool includeJob)
        {
            if (includeJob)
            {
                return await _context.Companies.Where(c => c.Id == companyId).Include(c => c.Jobs)
                    .FirstOrDefaultAsync();
            }

            return await GetCompanyAsync(companyId);
        }

        public async Task<bool> AddCompanyAsync(Company company)
        {
            await _context.Companies.AddAsync(company);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
