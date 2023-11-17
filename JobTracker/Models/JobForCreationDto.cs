using JobTracker.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JobTracker.Models
{
    public class JobForCreationDto
    {
        public string JobTitle { get; set; }
        [DataType(DataType.Currency)]
        public Salary? Salary { get; set; }
        public Location? Location { get; set; }
    }
}
