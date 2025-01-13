namespace Time.Domain.Request
{
    public class ProjectRequest
    {
        public string Name { get; set; }
        public decimal TotalHours { get; set; }
        public decimal Balance { get; set; }
        public bool IsSharedGlobally { get; set; }
        public DateTime? ClosedOn { get; set; }
    }
}