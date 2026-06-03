using HospitalAPI.Models;

namespace HospitalAPI.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task Add(Doctor doctor);

        Task Update(int doctorId, Doctor doctor);

        Task<List<Doctor>> GetAvailableDoctors();

        Task<Doctor?> GetDoctorById(int doctorId);

        Task<List<Doctor>> GetDoctorsBySpecialization(string specialization);

        Task<List<Doctor>> GetAllDoctors();
    }
}