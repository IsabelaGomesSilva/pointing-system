using System.Text.Json.Serialization;

namespace Time.Domain
{
    public class AppointmentRule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string RuleSyntax { get; set; }
        private int _isEnable;
    
        [JsonPropertyName("IsEnable")]
        public int IsEnable
        {
            get => _isEnable;
            set
            {
                _isEnable = value;
                IsEnableBool = value == 1;
            }
        }

        [JsonIgnore]
        public bool IsEnableBool { get; private set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int RuleTypeId { get; set; }
        public int Order { get; set; }
    }

}
