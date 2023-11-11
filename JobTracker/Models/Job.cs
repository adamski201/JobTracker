namespace JobTracker.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string EmployerName { get; set; }
        public string JobTitle { get; set; }
        public float Salary { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
    }
}
