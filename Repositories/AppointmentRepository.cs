using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalAPI.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly string _con;

        public AppointmentRepository(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection");
        }

        public async Task<int> BookAppointment(Appointment appointment)
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_BookingAppointments", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
            cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);

            await con.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();

            return Convert.ToInt32(result);
        }

        public async Task<string> CancelAppointment(int appointmentId)
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_CancelAppointment", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

            await con.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();

            return result?.ToString();
        }

        public async Task<IEnumerable<UpcomingAppointment>> GetUpcomingAppointments()
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_GetUpcomingAppointments", con);

            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<UpcomingAppointment>();

            while (await reader.ReadAsync())
            {
                list.Add(new UpcomingAppointment
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    PatientName = reader["PatientName"].ToString(),
                    DoctorName = reader["DoctorName"].ToString(),
                    Specialization = reader["Specialization"].ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"].ToString()
                });
            }

            return list;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_GetAllAppointments", con);

            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<Appointment>();

            while (await reader.ReadAsync())
            {
                list.Add(new Appointment
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    PatientId = Convert.ToInt32(reader["PatientId"]),
                    DoctorId = Convert.ToInt32(reader["DoctorId"]),
                    PatientName = reader["PatientName"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString(),
                    Specialization = reader["Specialization"]?.ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"]?.ToString()
                });
            }

            return list;
        }

        public async Task<Appointment> GetAppointmentById(int appointmentId)
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_GetAppointmentById", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

            await con.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Appointment
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    PatientId = Convert.ToInt32(reader["PatientId"]),
                    DoctorId = Convert.ToInt32(reader["DoctorId"]),
                    PatientName = reader["PatientName"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString(),
                    Specialization = reader["Specialization"]?.ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"]?.ToString()
                };
            }

            return null;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId)
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_GetAppointmentsByDoctor", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DoctorId", doctorId);

            await con.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<Appointment>();

            while (await reader.ReadAsync())
            {
                list.Add(new Appointment
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    PatientName = reader["PatientName"]?.ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"]?.ToString()
                });
            }

            return list;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId)
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_GetAppointmentsByPatient", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PatientId", patientId);

            await con.OpenAsync();
            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<Appointment>();

            while (await reader.ReadAsync())
            {
                list.Add(new Appointment
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    DoctorName = reader["DoctorName"]?.ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"]?.ToString()
                });
            }

            return list;
        }

        public async Task<int> UpdateAppointment(Appointment appointment)
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_UpdateAppointment", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
            cmd.Parameters.AddWithValue("@PatientId", appointment.PatientId);
            cmd.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@Status", appointment.Status);

            await con.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();

            return Convert.ToInt32(result);
        }

        public async Task<string> CompleteAppointment(int appointmentId)
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_CompleteAppointment", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AppointmentId", appointmentId);

            await con.OpenAsync();
            var result = await cmd.ExecuteScalarAsync();

            return result?.ToString();
        }
    }
}