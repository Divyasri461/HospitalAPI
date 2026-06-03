using HospitalAPI.DTOs.AppointmentDto;

namespace HospitalAPI.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<AppointmentReportDto>> GetAppointmentReport();

        Task<IEnumerable<RevenueBySpecializationDto>> GetRevenueBySpecialization();

        Task<IEnumerable<DoctorAppointmentCountDto>> GetDoctorAppointmentCounts();

        Task<IEnumerable<SameDoctorSameDatePatientsDto>> GetSameDoctorSameDatePatients();

        Task<IEnumerable<Upcoming7DaysAppointmentDto>> GetAppointmentsNext7Days();
    }
}
