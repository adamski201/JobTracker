using JobTracker.Domain.Entities;

namespace JobTracker.Models
{
    public class CompanyForUpdateDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Industry { get; set; }
        public Location? Location { get; set; }
    }
}
