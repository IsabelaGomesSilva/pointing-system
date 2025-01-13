using System.Text.Json;
using Time.Domain;

namespace Time.Service
{
    public class LoadRulesFromJson
    {
        public static List<AppointmentRule> LoadRules()
        {
            string jsonString = File.ReadAllText("Results.json");

            var rules = JsonSerializer.Deserialize<List<AppointmentRule>>(jsonString);

            return rules;
        }
    }
}
