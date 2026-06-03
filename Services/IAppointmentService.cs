using HospitalAPI.DTOs.AppointmentDto;

namespace HospitalAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<object> BookAppointment(CreateAppointmentDto dto);
        Task<string> CancelAppointment(int appointmentId);

        Task<IEnumerable<AppointmentDto>> GetAllAppointments();
        Task<AppointmentDto> GetAppointmentById(int appointmentId);

        Task<IEnumerable<UpcomingAppointmentDto>> GetUpcomingAppointments();

        Task<IEnumerable<DoctorAppointmentDto>> GetAppointmentsByDoctor(int doctorId);
        Task<IEnumerable<PatientAppointmentDto>> GetAppointmentsByPatient(int patientId);
        Task<object> UpdateAppointment(UpdateAppointmentDto dto);
        Task<string> CompleteAppointment(CompleteAppointmentDto dto);

    }
}