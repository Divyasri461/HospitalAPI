using HospitalAPI.Models;

namespace HospitalAPI.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Appointment>> GetAppointmentReport();

        Task<IEnumerable<RevenueBySpecialization>> GetRevenueBySpecialization();

        Task<IEnumerable<DoctorAppointmentCount>> GetDoctorAppointmentCounts();

        Task<IEnumerable<SameDoctorSameDatePatients>> GetSameDoctorSameDatePatients();

        Task<IEnumerable<Appointment>> GetAppointmentsNext7Days();
    }
}
