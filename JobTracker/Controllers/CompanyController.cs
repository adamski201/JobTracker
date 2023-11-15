using AutoMapper;
using JobTracker.Data_Access.Repositories;
using JobTracker.Domain.Entities;
using JobTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JobTracker.Controllers
{
    [ApiController]
    [Route("api/companies")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompaniesAsync(bool includeJobs = false)
        {
            var companies = await _companyRepository.GetCompaniesAsync(includeJobs);

            if (includeJobs)
            {
                return Ok(_mapper.Map<IEnumerable<CompanyDto>>(companies));
            }

            return Ok(_mapper.Map<IEnumerable<CompanyWithoutJobsDto>>(companies));
        }

        
    }
}
