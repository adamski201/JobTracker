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
        public async Task<IActionResult> GetCompanies(bool includeJobs = false)
        {
            var companies = await _companyRepository.GetCompaniesAsync(includeJobs);

            if (includeJobs)
            {
                return Ok(_mapper.Map<IEnumerable<CompanyDto>>(companies));
            }

            return Ok(_mapper.Map<IEnumerable<CompanyWithoutJobsDto>>(companies));
        }

        [HttpGet("{companyId}", Name = "GetCompany")]
        public async Task<IActionResult> GetCompany(int companyId, bool includeJob = false)
        {
            var company = await _companyRepository.GetCompanyAsync(companyId, includeJob);

            if (company == null)
            {
                return NotFound();
            }

            if (includeJob)
            {
                return Ok(_mapper.Map<CompanyDto>(company));
            }

            return Ok(_mapper.Map<CompanyWithoutJobsDto>(company));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyForCreationDto company)
        {
            if (company == null)
            {
                return BadRequest();
            }

            var companyToCreate = _mapper.Map<Company>(company);

            if (!await _companyRepository.AddCompanyAsync(companyToCreate))
            {
                return StatusCode(500, "An error occurred while handling your request.");
            }

            var companyToReturn = _mapper.Map<CompanyDto>(companyToCreate);

            return CreatedAtRoute("GetCompany", new { companyId = companyToReturn.Id }, companyToReturn);
        }
    }
}
