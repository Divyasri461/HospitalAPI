using HospitalAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using HospitalAPI.Repositories.Interfaces;

namespace HospitalAPI.Repositories
{
    public class PatientRepository:IPatientRepository
    {
        private readonly string _con;

        public PatientRepository(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection");
        }

        // Add Patient
        public async Task Add(Patient patient)
        {
            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand("sp_RegisterStudents", con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@PatientCode",
                patient.PatientCode);

            cmd.Parameters.AddWithValue(
                "@FullName",
                patient.FullName);

            cmd.Parameters.AddWithValue(
                "@DateOfBirth",
                patient.DateOfBirth);

            cmd.Parameters.AddWithValue(
                "@Gender",
                patient.Gender);

            cmd.Parameters.AddWithValue(
                "@PhoneNumber",
                patient.PhoneNumber);

            cmd.Parameters.AddWithValue(
                "@Email",
                (object?)patient.Email ?? DBNull.Value);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }

        // Update Patient
        public async Task Update(
            int patientId,
            Patient patient)
        {
            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_UpdatePatient",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@PatientId",
                patientId);

            cmd.Parameters.AddWithValue(
                "@FullName",
                patient.FullName);

            cmd.Parameters.AddWithValue(
                "@DateOfBirth",
                patient.DateOfBirth);

            cmd.Parameters.AddWithValue(
                "@Gender",
                patient.Gender);

            cmd.Parameters.AddWithValue(
                "@PhoneNumber",
                patient.PhoneNumber);

            cmd.Parameters.AddWithValue(
                "@Email",
                (object?)patient.Email ?? DBNull.Value);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }

        // Get All Active Patients
        public async Task<List<Patient>> GetAllActivePatients()
        {
            List<Patient> patients =
                new List<Patient>();

            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_GetAllActivePatients",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            await con.OpenAsync();

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                patients.Add(new Patient
                {
                    PatientId = Convert.ToInt32(reader["PatientId"]),

                    PatientCode = reader["PatientCode"].ToString(),

                    FullName = reader["FullName"].ToString(),

                    DateOfBirth = Convert.ToDateTime( reader["DateOfBirth"]),

                    Gender = reader["Gender"] .ToString(),

                    PhoneNumber = reader["PhoneNumber"] .ToString(),

                    Email = reader["Email"] == DBNull.Value
                       ? null
                      : reader["Email"].ToString(),

                    IsActive = true
                });
            }

            return patients;
        }

        // Deactivate Patient
        public async Task Delete(int patientId)
        {
            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_DeactivatePatient",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@PatientId",
                patientId);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }

        // Get Patient By Id
        public async Task<Patient?> GetById(int patientId)
        {
            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_GetPatientById",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@PatientId",
                patientId);

            await con.OpenAsync();

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            return new Patient
            {
                PatientId = Convert.ToInt32(
                    reader["PatientId"]),

                PatientCode = reader["PatientCode"]
                    .ToString(),

                FullName = reader["FullName"]
                    .ToString(),

                DateOfBirth = Convert.ToDateTime(
                    reader["DateOfBirth"]),

                Gender = reader["Gender"]
                    .ToString(),

                PhoneNumber = reader["PhoneNumber"]
                    .ToString(),

                Email = reader["Email"] == DBNull.Value
                    ? null
                    : reader["Email"].ToString(),

                IsActive = Convert.ToBoolean(
                    reader["IsActive"]),

                CreatedAt = Convert.ToDateTime(
                    reader["CreatedAt"]),

                UpdatedAt = reader["UpdatedAt"] == DBNull.Value
                    ? null
                    : Convert.ToDateTime(
                        reader["UpdatedAt"])
            };
        }

        // Search Patients
        public async Task<List<Patient>> SearchPatients(
            string searchTerm)
        {
            List<Patient> patients =
                new List<Patient>();

            using SqlConnection con =
                new SqlConnection(_con);

            SqlCommand cmd =
                new SqlCommand(
                    "sp_SearchPatients",
                    con);

            cmd.CommandType =
                CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue(
                "@SearchTerm",
                searchTerm);

            await con.OpenAsync();

            SqlDataReader reader =
                await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                patients.Add(new Patient
                {
                    PatientId = Convert.ToInt32(
                        reader["PatientId"]),

                    PatientCode = reader["PatientCode"]
                        .ToString(),

                    FullName = reader["FullName"]
                        .ToString(),

                    DateOfBirth = Convert.ToDateTime(
                        reader["DateOfBirth"]),

                    Gender = reader["Gender"]
                        .ToString(),

                    PhoneNumber = reader["PhoneNumber"]
                        .ToString(),

                    Email = reader["Email"] == DBNull.Value
                        ? null
                        : reader["Email"].ToString(),

                    IsActive = Convert.ToBoolean(
                        reader["IsActive"])
                });
            }

            return patients;
        }
    }
}