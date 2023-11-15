using AutoMapper;
using JobTracker.Domain.Entities;

namespace JobTracker.Models.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile() 
        {
            CreateMap<Company, CompanyWithoutJobsDto>();
            CreateMap<Company, CompanyDto>();
        }
    }
}
