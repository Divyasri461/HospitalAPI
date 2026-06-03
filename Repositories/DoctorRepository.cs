using HospitalAPI.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using HospitalAPI.Repositories.Interfaces;
namespace HospitalAPI.Repositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly string _con;

        public DoctorRepository(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection");
        }

        public async Task Add(Doctor doctor)
        {
            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand("sp_AddDoctor", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@DoctorCode",
                doctor.DoctorCode);

            cmd.Parameters.AddWithValue(
                "@FullName",
                doctor.FullName);

            cmd.Parameters.AddWithValue(
                "@Specialization",
                doctor.Specialization);

            cmd.Parameters.AddWithValue(
                "@PhoneNumber",
                doctor.PhoneNumber);

            cmd.Parameters.AddWithValue(
                "@ConsultationFee",
                doctor.ConsultationFee);

            cmd.Parameters.AddWithValue(
                "@IsAvailable",
                doctor.IsAvailable);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }
        public async Task Update(int doctorId, Doctor doctor)
        {
            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand("sp_UpdateDoctor", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@DoctorId",
                doctorId);

            cmd.Parameters.AddWithValue(
                "@FullName",
                doctor.FullName);

            cmd.Parameters.AddWithValue(
                "@Specialization",
                doctor.Specialization);

            cmd.Parameters.AddWithValue(
                "@PhoneNumber",
                doctor.PhoneNumber);

            cmd.Parameters.AddWithValue(
                "@ConsultationFee",
                doctor.ConsultationFee);

            cmd.Parameters.AddWithValue(
                "@IsAvailable",
                doctor.IsAvailable);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }
        public async Task<List<Doctor>> GetAvailableDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_GetAvailableDoctors",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            await con.OpenAsync();

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                doctors.Add(new Doctor
                {
                    DoctorId = Convert.ToInt32(
                        reader["DoctorId"]),

                    DoctorCode = reader["DoctorCode"] .ToString(),

                    FullName = reader["FullName"] .ToString(),

                    Specialization = reader["Specialization"]
                        .ToString(),

                    PhoneNumber = reader["PhoneNumber"]
                        .ToString(),

                    ConsultationFee = Convert.ToDecimal(
                        reader["ConsultationFee"]),

                    IsAvailable = Convert.ToBoolean(
                        reader["IsAvailable"]),

                    CreatedAt = Convert.ToDateTime(
                        reader["CreatedAt"]),

                    UpdatedAt = reader["UpdatedAt"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(
                            reader["UpdatedAt"])
                });
            }

            return doctors;
        }
        public async Task<Doctor?> GetDoctorById(int doctorId)
        {
            Doctor? doctor = null;

            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand("sp_GetDoctorById", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@DoctorId",
                doctorId);

            await con.OpenAsync();

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                doctor = new Doctor
                {
                    DoctorId = Convert.ToInt32(reader["DoctorId"]),
                    DoctorCode = reader["DoctorCode"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    Specialization = reader["Specialization"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"]),
                    IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                    CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                    UpdatedAt = reader["UpdatedAt"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(reader["UpdatedAt"])
                };
            }

            return doctor;
        }
        public async Task<List<Doctor>>
    GetDoctorsBySpecialization(
        string specialization)
        {
            List<Doctor> doctors = new();

            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_GetDoctorsBySpecialization",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@Specialization",
                specialization);

            await con.OpenAsync();

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                doctors.Add(new Doctor
                {
                    DoctorId = Convert.ToInt32(reader["DoctorId"]),
                    DoctorCode = reader["DoctorCode"].ToString(),
                    FullName = reader["FullName"].ToString(),
                    Specialization = reader["Specialization"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"]),
                    IsAvailable = Convert.ToBoolean(reader["IsAvailable"])
                });
            }

            return doctors;
        }
        public async Task<List<Doctor>> GetAllDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_GetAllDoctors",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            await con.OpenAsync();

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                doctors.Add(new Doctor
                {
                    DoctorId = Convert.ToInt32(
                        reader["DoctorId"]),

                    DoctorCode = reader["DoctorCode"]
                        .ToString(),

                    FullName = reader["FullName"]
                        .ToString(),

                    Specialization = reader["Specialization"]
                        .ToString(),

                    PhoneNumber = reader["PhoneNumber"]
                        .ToString(),

                    ConsultationFee = Convert.ToDecimal(
                        reader["ConsultationFee"]),

                    IsAvailable = Convert.ToBoolean(
                        reader["IsAvailable"]),

                    CreatedAt = Convert.ToDateTime(
                        reader["CreatedAt"]),

                    UpdatedAt = reader["UpdatedAt"] == DBNull.Value
                        ? null
                        : Convert.ToDateTime(
                            reader["UpdatedAt"])
                });
            }

            return doctors;
        }
    }
}