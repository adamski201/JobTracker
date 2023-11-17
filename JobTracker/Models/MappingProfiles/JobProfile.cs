using AutoMapper;
using JobTracker.Domain.Entities;

namespace JobTracker.Models.MappingProfiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDto>();
            CreateMap<JobForCreationDto, Job>();
        }
    }
}
