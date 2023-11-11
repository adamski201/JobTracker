using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Entities
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployerName { get; set; }
        [Required]
        [MaxLength(50)]
        public string JobTitle { get; set; }
        [MaxLength(50)]
        public string? City { get; set; }
        public float Salary { get; set; }
        [StringLength(200)]
        public string? Description { get; set; }
        public DateTime ApplicationDate { get; set; }
        public JobStatus? Status { get; set; }

        
    }

    public enum JobStatus
    {
        Waiting,
        Interview,
        Rejected,
        Success
    }
}
