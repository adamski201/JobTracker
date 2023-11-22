using AutoMapper;
using JobTracker.Data_Access.Repositories;
using JobTracker.Domain.Entities;
using JobTracker.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SQLitePCL;

namespace JobTracker.Controllers
{
    [ApiController]
    [Route("api/applications")]
    public class JobApplicationController : ControllerBase
    {
        private readonly IJobApplicationRepository _repository;
        private readonly IMapper _mapper;
        private const int maxPageSize = 10;

        public JobApplicationController(IJobApplicationRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> GetJobApplications(bool includeJob = false)
        {
            var applications = await _repository.GetJobApplicationsAsync(includeJob);

            if (includeJob)
            {
                return Ok(_mapper.Map<IEnumerable<JobApplicationDto>>(applications));
            }

            return Ok(_mapper.Map<IEnumerable<JobApplicationWithoutJobDto>>(applications));
        }

        [HttpGet("{applicationId}", Name = "GetJobApplication")]
        public async Task<IActionResult> GetJobApplication(int applicationId, bool includeJob = false)
        {
            var application = await _repository.GetJobApplicationAsync(applicationId, includeJob);

            if (application == null)
            {
                return NotFound();
            }

            if (includeJob)
            {
                return Ok(_mapper.Map<JobApplicationDto>(application));
            }

            return Ok(_mapper.Map<JobApplicationWithoutJobDto>(application));
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobApplication(JobApplicationForCreationDto application)
        {
            if (application == null)
            {
                return BadRequest();
            }

            var applicationToCreate = _mapper.Map<JobApplication>(application);

            if (!await _repository.AddJobApplicationAsync(applicationToCreate))
            {
                return StatusCode(500, "An error occurred while handling your request.");
            }

            var applicationToReturn = _mapper.Map<JobApplicationDto>(applicationToCreate);

            return CreatedAtRoute("GetJobApplication", new { applicationId = applicationToReturn.Id }, applicationToReturn);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveJobApplication(int applicationId)
        {
            var application = await _repository.GetJobApplicationAsync(applicationId);
            if (application == null)
            {
                return NotFound();
            }

            if (!await _repository.DeleteJobApplicationAsync(application))
            {
                return StatusCode(500, "An error occurred while handling your request.");
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJobApplication(int applicationId, JobApplicationForUpdateDto application)
        {
            if (application == null)
            {
                return BadRequest();
            }

            var applicationToUpdate = await _repository.GetJobApplicationAsync(applicationId);
            if (applicationToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(application, applicationToUpdate);

            await _repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch]
        public async Task<IActionResult> PartiallyUpdateJobApplication(int applicationId, JsonPatchDocument<JobApplicationForUpdateDto> patchDocument)
        {
            var application = await _repository.GetJobApplicationAsync(applicationId, true);

            if (application == null)
            {
                return NotFound();
            }

            var applicationToUpdate = _mapper.Map<JobApplicationForUpdateDto>(application);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            patchDocument.ApplyTo(applicationToUpdate);

            if (!TryValidateModel(applicationToUpdate))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(applicationToUpdate, application);

            await _repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
