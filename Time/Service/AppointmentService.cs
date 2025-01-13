using Time.Domain;
using Time.Domain.request;

namespace Time.Service.Interfaces
{
    public class AppointmentService: IAppointmentService
    {
        private readonly Context _context;

        public AppointmentService(Context context)
        {
            _context = context;
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAllAppointments()
        {
            return _context.Appointments.ToList();
        }

        public int CreateAppointment(AppointmentRequest appointmentRequest)
        {
            List<AppointmentRule> rules = LoadRulesFromJson.LoadRules();

            Appointment appointment = new Appointment{
                StartTime = appointmentRequest.StartTime,
                FinishTime = appointmentRequest.FinishTime,
                OnSite = appointmentRequest.OnSite,
                Date = appointmentRequest.Date,
                Description = appointmentRequest.Description,
                AccountId = appointmentRequest.AccountId,
                TaskId = appointmentRequest.TaskId,
                InternalId = appointmentRequest.InternalId,
            };
          
            appointment.IsApproved = AppointmentValidator.ValidateAppointment(appointment, rules);

            _context.Appointments.Add(appointment);
            _context.SaveChanges();

            return appointment.Id;
        }
    }
}