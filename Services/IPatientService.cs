using HospitalAPI.DTOs;

namespace HospitalAPI.Services.Interfaces
{
    public interface IPatientService
    {
        Task Add(CreatePatientDto dto);

        Task Update(int patientId, UpdatePatientDto dto);

        Task<List<GetActivePatientDto>> GetAllActivePatients();

        Task Delete(int patientId);

        Task<GetPatientByIdDto?> GetById(int patientId);

        Task<List<SearchPatientDto>> SearchPatients(string searchTerm);
    }
}