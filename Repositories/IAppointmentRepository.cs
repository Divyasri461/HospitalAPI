using HospitalAPI.Models;

namespace HospitalAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task<int> BookAppointment(Appointment appointment);

        Task<string> CancelAppointment(int appointmentId);

        Task<IEnumerable<UpcomingAppointment>> GetUpcomingAppointments();

        Task<IEnumerable<Appointment>> GetAllAppointments();

        Task<Appointment> GetAppointmentById(int appointmentId);

        Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId);

        Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId);

        Task<int> UpdateAppointment(Appointment appointment);

        Task<string> CompleteAppointment(int appointmentId);
    }
}
