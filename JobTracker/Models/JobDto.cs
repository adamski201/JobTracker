using JobTracker.Domain.Entities;

namespace JobTracker.Models
{
    public class JobDto
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public Salary? Salary { get; set; }
        public Location? Location { get; set; }
    }
}
