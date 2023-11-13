namespace JobTracker.Domain.Entities
{
    public class Interview
    {
        public int Id { get; set; }
        public InterviewStatus Status { get; set; }
        public DateTime InterviewDate { get; set; }
        public DateTime Deadline { get; set; }
        public InterviewType Type { get; set; }
    }

    public enum InterviewType
    {
        PhoneScreening,
        VideoInterview,
        Online,
        InPerson,
        AssessmentDay
    }

    public enum InterviewStatus
    {
        Upcoming,
        WaitingForResult,
        Passed,
        Failed
    }
}