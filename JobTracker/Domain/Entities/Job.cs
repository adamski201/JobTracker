﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace JobTracker.Domain.Entities
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string JobTitle { get; set; }
        public Company Company { get; set; }
        public int CompanyId { get; set; }
        [DataType(DataType.Currency)]
        public Salary? Salary { get; set; }
        public Location? Location { get; set; }
    }
}
