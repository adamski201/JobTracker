﻿using JobTracker.Domain.Entities;

namespace JobTracker.Models
{
    public class CompanyWithoutJobsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public Location? Location { get; set; }
        public string? Industry { get; set; }
    }
}
