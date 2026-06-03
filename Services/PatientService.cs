using HospitalAPI.DTOs;
using HospitalAPI.Models;
using HospitalAPI.Repositories;
using HospitalAPI.Services.Interfaces;
using HospitalAPI.Repositories.Interfaces;
namespace HospitalAPI.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        // Add Patient
        public async Task Add(CreatePatientDto dto)
        {
            var patient = new Patient
            {
                PatientCode = dto.PatientCode,
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            await _repo.Add(patient);
        }

        // Update Patient
        public async Task Update(int patientId, UpdatePatientDto dto)
        {
            var patient = new Patient
            {
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                Gender = dto.Gender,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email
            };

            await _repo.Update(patientId, patient);
        }

        // Get All Active Patients
        public async Task<List<GetActivePatientDto>> GetAllActivePatients()
        {
            var patients = await _repo.GetAllActivePatients();

            return patients.Select(p => new GetActivePatientDto
            {
                PatientId = p.PatientId,
                PatientCode = p.PatientCode,
                FullName = p.FullName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
               Age=p.GetAge()

            }).ToList();
        }

        // Deactivate Patient

        public async Task Delete(int patientId)
        {
            var patient = await _repo.GetById(patientId);

            if (patient == null)
                throw new Exception("Patient not found");

            // ✅ CHECK BEFORE DELETE
            if (!patient.IsActive)
                throw new ApplicationException("Patient already inactive");

            // ✅ NOW DELETE
            await _repo.Delete(patientId);
        }


        // Get Patient By Id
        public async Task<GetPatientByIdDto?> GetById(int patientId)
        {
            var patient = await _repo.GetById(patientId);

            if (patient == null)
                return null;

            return new GetPatientByIdDto
            {
                PatientId = patient.PatientId,
                PatientCode = patient.PatientCode,
                FullName = patient.FullName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                IsActive = patient.IsActive,
                CreatedAt = patient.CreatedAt,
                UpdatedAt = patient.UpdatedAt
            };
        }

        // Search Patients
        public async Task<List<SearchPatientDto>> SearchPatients(string searchTerm)
        {
            var patients = await _repo.SearchPatients(searchTerm);

            return patients.Select(p => new SearchPatientDto
            {
                PatientId = p.PatientId,
                PatientCode = p.PatientCode,
                FullName = p.FullName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email,
                IsActive = p.IsActive
            }).ToList();
        }
    }
}