using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JobTracker.Domain.Entities
{
    public class JobApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Job Job { get; set; }
        public DateTime InitialApplicationDate { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
