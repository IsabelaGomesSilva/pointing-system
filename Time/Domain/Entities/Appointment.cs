using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.Net.Http.Headers;

namespace Time.Domain
{
    public class Appointment
    {
        public Appointment() {}
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string InternalId { get; set; }
        public int TaskId { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan StartTime { get; set; }
         
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan FinishTime { get; set; }
        public bool OnSite { get; set; }
        public bool IsApproved { get; set; }
        public bool IsBillable { get; set; }
        public bool IsArchived { get; set; }
        public string CreatedBy { get; set; } = "Isabela Silva";
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public double TotalHours 
        {
            get 
            {
                return (FinishTime - StartTime).TotalHours;
            }
        }       
    }
}
