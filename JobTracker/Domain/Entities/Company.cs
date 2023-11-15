using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobTracker.Domain.Entities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Industry { get; set; }
        public Location? Location { get; set; }
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
