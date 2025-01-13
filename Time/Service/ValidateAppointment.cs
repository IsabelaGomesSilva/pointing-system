using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Time.Domain;

namespace Time.Service
{
    public class AppointmentValidator
    {
        private readonly Context _context;

        public AppointmentValidator(Context context)
        {
            _context = context;
        }
        private double ValidateTotalHoras(Appointment appointment)
        {
            List<Appointment> appointmentExist = _context.Appointments
                                                    .Where(a => a.Date == appointment.Date)
                                                    .ToList();
            double totalHours = appointment.TotalHours;
            foreach (var appoint in appointmentExist)
            {
              totalHours = totalHours + appoint.TotalHours;
            }

            return totalHours;
        }
        public static bool ValidateAppointment(Appointment appointment, List<AppointmentRule> rules)
        {
           
            var sortedRules = rules.Where(r => r.IsEnable == 1)
                                   .OrderBy(r => r.Order)
                                   .ToList();
            foreach (var rule in sortedRules)
            {
                var expression = rule.RuleSyntax
                    .Replace("startTime", $"\"{appointment.StartTime}\"") 
                    .Replace("finishTime", $"\"{appointment.FinishTime}\"")
                    .Replace("internalId", $"\"{appointment.InternalId}\"")
                    .Replace("date", $"\"{appointment.Date:yyyy-MM-dd}\"") 
                    .Replace("onSite", appointment.OnSite.ToString().ToLower())
                    .Replace("createdOn",  $"\"{appointment.CreatedOn:yyyy-MM-ddTHH:mm:ss}\"") 
                    .Replace("taskId",$"{appointment.TaskId}")
                    .Replace("accountId", $"{appointment.AccountId}")
                    .Replace("description", $"\"{appointment.Description}\"")
                    .Replace("totalHours", $"{appointment.TotalHours}");

                var result = CSharpScript.EvaluateAsync<bool>(expression).Result;
                   
                if (result)
                {
                    return true;
                }
            }

            return false;
        }
    }

}
