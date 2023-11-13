using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace JobTracker.Domain.Entities
{
    public class Job
    {
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public Company Employer { get; set; }
        [DataType(DataType.Currency)]
        public Salary? Salary { get; set; }
        public Location? Location { get; set; }
    }


}
