using HospitalAPI.DTOs.AppointmentDto;
using HospitalAPI.Repositories.Interfaces;
using HospitalAPI.Services.Interfaces;
using HospitalAPI.Repositories;
namespace HospitalAPI.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repo;

        public ReportService(IReportRepository repo)
        {
            _repo = repo;
        }

        // ✅ FULL REPORT
        public async Task<IEnumerable<AppointmentReportDto>> GetAppointmentReport()
        {
            var data = await _repo.GetAppointmentReport();

            return data.Select(x => new AppointmentReportDto
            {
                AppointmentId = x.AppointmentId,
                PatientName = x.PatientName,
                DoctorName = x.DoctorName,
                Specialization = x.Specialization,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status,
                ConsultationFee = x.ConsultationFee
            });
        }

        // ✅ REVENUE
        public async Task<IEnumerable<RevenueBySpecializationDto>> GetRevenueBySpecialization()
        {
            var data = await _repo.GetRevenueBySpecialization();

            return data.Select(x => new RevenueBySpecializationDto
            {
                Specialization = x.Specialization,
                TotalRevenue = x.TotalRevenue
            });
        }

        // ✅ DOCTOR COUNT
        public async Task<IEnumerable<DoctorAppointmentCountDto>> GetDoctorAppointmentCounts()
        {
            var data = await _repo.GetDoctorAppointmentCounts();

            return data.Select(x => new DoctorAppointmentCountDto
            {
                DoctorId = x.DoctorId,
                DoctorCode = x.DoctorCode,
                DoctorName = x.DoctorName,
                Specialization = x.Specialization,
                TotalAppointments = x.TotalAppointments
            });
        }

        // ✅ SAME DOCTOR SAME DATE
        public async Task<IEnumerable<SameDoctorSameDatePatientsDto>> GetSameDoctorSameDatePatients()
        {
            var data = await _repo.GetSameDoctorSameDatePatients();

            return data.Select(x => new SameDoctorSameDatePatientsDto
            {
                DoctorName = x.DoctorName,
                AppointmentDate = x.AppointmentDate,
                TotalPatients = x.TotalPatients
            });
        }

        // ✅ NEXT 7 DAYS
        public async Task<IEnumerable<Upcoming7DaysAppointmentDto>> GetAppointmentsNext7Days()
        {
            var data = await _repo.GetAppointmentsNext7Days();

            return data.Select(x => new Upcoming7DaysAppointmentDto
            {
                AppointmentId = x.AppointmentId,
                PatientName = x.PatientName,
                DoctorName = x.DoctorName,
                Specialization = x.Specialization,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status
            });
        }
    }
}