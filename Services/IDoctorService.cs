using HospitalAPI.DTOs.DoctorDto;
using HospitalAPI.Models;

namespace HospitalAPI.Services.Interfaces
{
    public interface IDoctorService
    {
        Task Create(CreateDoctorDto dto);

        Task Update(int doctorId, UpdateDoctorDto dto);

        Task<List<Doctor>> GetAvailableDoctors();

        Task<Doctor?> GetDoctorById(int doctorId);

        Task<List<Doctor>> GetDoctorsBySpecialization(string specialization);

        Task<List<Doctor>> GetAllDoctors();
    }
}