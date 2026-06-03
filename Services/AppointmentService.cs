using HospitalAPI.DTOs.AppointmentDto;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using HospitalAPI.Services.Interfaces;
using System.Linq;

namespace HospitalAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;
        

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }

        // -------------------------
        // BOOK APPOINTMENT
        // -------------------------
        public async Task<object> BookAppointment(CreateAppointmentDto dto)
        {
            if (dto.AppointmentDate <= DateTime.Now)
                throw new Exception("Appointment date must be in future");

            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                Status = "Scheduled",
                CreatedAt = DateTime.Now
            };

            var result = await _repo.BookAppointment(appointment);

            return new
            {
                AppointmentId = result,
                Message = "Appointment booked successfully"
            };
        }

        // -------------------------
        // CANCEL APPOINTMENT
        // -------------------------
        public async Task<string> CancelAppointment(int appointmentId)
        {
            return await _repo.CancelAppointment(appointmentId);
        }
        public async Task<IEnumerable<UpcomingAppointmentDto>> GetUpcomingAppointments()
        {
            var data = await _repo.GetUpcomingAppointments();

            return data.Select(x => new UpcomingAppointmentDto
            {
                AppointmentId = x.AppointmentId,
                PatientName = x.PatientName,
                DoctorName = x.DoctorName,
                Specialization = x.Specialization,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status
            });
        }
        public async Task<IEnumerable<AppointmentDto>> GetAllAppointments()
        {
            var data = await _repo.GetAllAppointments();

            if (data == null)
                return Enumerable.Empty<AppointmentDto>();

            return data.Select(x => new AppointmentDto
            {
                AppointmentId = x.AppointmentId,
                PatientId = x.PatientId,
                DoctorId = x.DoctorId,
                PatientName = x.PatientName,
                DoctorName = x.DoctorName,
                Specialization = x.Specialization,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status
            });
        }
        public async Task<AppointmentDto> GetAppointmentById(int appointmentId)
        {
            var data = await _repo.GetAppointmentById(appointmentId);

            if (data == null)
                return null;

            return new AppointmentDto
            {
                AppointmentId = data.AppointmentId,
                PatientId = data.PatientId,
                DoctorId = data.DoctorId,
                PatientName = data.PatientName,
                DoctorName = data.DoctorName,
                Specialization = data.Specialization,
                AppointmentDate = data.AppointmentDate,
                Status = data.Status
            };
        }
        public async Task<IEnumerable<DoctorAppointmentDto>> GetAppointmentsByDoctor(int doctorId)
        {
            var data = await _repo.GetAppointmentsByDoctor(doctorId);

            return data.Select(x => new DoctorAppointmentDto
            {
                AppointmentId = x.AppointmentId,
                PatientName = x.PatientName,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status
            });
        }
        public async Task<IEnumerable<PatientAppointmentDto>> GetAppointmentsByPatient(int patientId)
        {
            var data = await _repo.GetAppointmentsByPatient(patientId);

            return data.Select(x => new PatientAppointmentDto
            {
                AppointmentId = x.AppointmentId,
                DoctorName = x.DoctorName,
                AppointmentDate = x.AppointmentDate,
                Status = x.Status
            });
        }
       
        public async Task<object> UpdateAppointment(UpdateAppointmentDto dto)
        {
            if (dto.AppointmentDate <= DateTime.Now)
                throw new Exception("Appointment date must be in future");

            var appointment = new Appointment
            {
                AppointmentId = dto.AppointmentId,
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                AppointmentDate = dto.AppointmentDate,
                Status = dto.Status
            };

            var result = await _repo.UpdateAppointment(appointment);

            return new
            {
                AppointmentId = result,
                Message = "Appointment updated successfully"
            };
        }
        public async Task<string> CompleteAppointment(CompleteAppointmentDto dto)
        {
            if (dto.AppointmentId <= 0)
                throw new Exception("Invalid Appointment Id");

            var result = await _repo.CompleteAppointment(dto.AppointmentId);

            return result;
        }
        
    }
    }
