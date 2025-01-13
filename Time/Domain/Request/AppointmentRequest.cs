using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Time.Domain.request
{
    public class AppointmentRequest
    {
        public string InternalId { get; set; }
        public int TaskId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan FinishTime { get; set; }
        public bool OnSite { get; set; }
    }
}