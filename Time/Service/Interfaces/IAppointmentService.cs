using Time.Domain;
using Time.Domain.request;

namespace Time.Service.Interfaces
{
    public interface IAppointmentService
    {
         Appointment GetAppointmentById(int id);
        IEnumerable<Appointment> GetAllAppointments();
        int CreateAppointment(AppointmentRequest appointment);
    }
}