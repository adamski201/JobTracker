using JobTracker.Domain.Entities;

namespace JobTracker.Models
{
    public class JobForUpdateDto
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public Salary? Salary { get; set; }
        public Location? Location { get; set; }
    }
}
