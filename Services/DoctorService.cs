using HospitalAPI.DTOs.DoctorDto;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Repositories;
using HospitalAPI.Services.Interfaces;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Services
{

    public class DoctorService: IDoctorService
    {
        private readonly IDoctorRepository _repo;
        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }
        public async Task Create(CreateDoctorDto dto)
        {
            var doctor = new Doctor
            {
                DoctorCode = dto.DoctorCode,
                FullName = dto.FullName,
                Specialization = dto.Specialization,
                PhoneNumber = dto.PhoneNumber,
                ConsultationFee = dto.ConsultationFee,
                IsAvailable = dto.IsAvailable
            };

            await _repo.Add(doctor);
        }
        public async Task Update(
    int doctorId,
    UpdateDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FullName = dto.FullName,
                Specialization = dto.Specialization,
                PhoneNumber = dto.PhoneNumber,
                ConsultationFee = dto.ConsultationFee,
                IsAvailable = dto.IsAvailable
            };

            await _repo.Update(
                doctorId,
                doctor);
        }
        public async Task<List<Doctor>> GetAvailableDoctors() { 
           return await _repo.GetAvailableDoctors();
    }
        public async Task<Doctor?> GetDoctorById(int doctorId)
        {
            return await _repo.GetDoctorById(doctorId);
        }
        public async Task<List<Doctor>>
    GetDoctorsBySpecialization(
        string specialization)
        {
            return await _repo
                .GetDoctorsBySpecialization(
                    specialization);
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _repo.GetAllDoctors();
        }

    }
}
