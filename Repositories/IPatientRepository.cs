using HospitalAPI.Models;

namespace HospitalAPI.Repositories.Interfaces
{
    public interface IPatientRepository
    {
        Task Add(Patient patient);

        Task Update(int patientId, Patient patient);

        Task<List<Patient>> GetAllActivePatients();

        Task Delete(int patientId);

        Task<Patient?> GetById(int patientId);

        Task<List<Patient>> SearchPatients(string searchTerm);
    }
}