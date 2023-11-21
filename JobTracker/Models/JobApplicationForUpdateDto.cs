using JobTracker.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobTracker.Models
{
    public class JobApplicationForUpdateDto
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public Salary? Salary { get; set; }
        public Location? Location { get; set; }
    }
}
