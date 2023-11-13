namespace JobTracker.Domain.Entities
{
    public class Salary
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }

    public enum Currency
    {
        GBP,
        USD,
        Euro
    }
}