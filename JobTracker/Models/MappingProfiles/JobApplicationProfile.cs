using AutoMapper;
using JobTracker.Domain.Entities;

namespace JobTracker.Models.MappingProfiles
{
    public class JobApplicationProfile : Profile
    {
        public JobApplicationProfile() 
        {
            CreateMap<JobApplicationForCreationDto, JobApplication>();
            CreateMap<JobApplication, JobApplicationDto>();
            CreateMap<JobApplication, JobApplicationWithoutJobDto>();
            CreateMap<JobApplication, JobApplicationForUpdateDto>();
            CreateMap<JobApplicationForUpdateDto, JobApplication>();
        }
    }
}
