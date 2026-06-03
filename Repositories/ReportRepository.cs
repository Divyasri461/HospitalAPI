using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace HospitalAPI.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly string _con;

        public ReportRepository(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentReport()
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_AppointmentReport", con);

            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<Appointment>();

            while (await reader.ReadAsync())
            {
                list.Add(new Appointment
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    PatientName = reader["PatientName"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString(),
                    Specialization = reader["Specialization"]?.ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"]?.ToString(),
                    ConsultationFee = Convert.ToDecimal(reader["ConsultationFee"])
                });
            }

            return list;
        }

        public async Task<IEnumerable<RevenueBySpecialization>> GetRevenueBySpecialization()
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_RevenueBySpecialization", con);

            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<RevenueBySpecialization>();

            while (await reader.ReadAsync())
            {
                list.Add(new RevenueBySpecialization
                {
                    Specialization = reader["Specialization"].ToString(),
                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                });
            }

            return list;
        }

        public async Task<IEnumerable<DoctorAppointmentCount>> GetDoctorAppointmentCounts()
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_DoctorAppointmentCounts", con);

            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<DoctorAppointmentCount>();

            while (await reader.ReadAsync())
            {
                list.Add(new DoctorAppointmentCount
                {
                    DoctorId = Convert.ToInt32(reader["DoctorId"]),
                    DoctorCode = reader["DoctorCode"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString(),
                    Specialization = reader["Specialization"]?.ToString(),
                    TotalAppointments = Convert.ToInt32(reader["TotalAppointments"])
                });
            }

            return list;
        }

        public async Task<IEnumerable<SameDoctorSameDatePatients>> GetSameDoctorSameDatePatients()
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_SameDoctorSameDatePatients", con);

            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<SameDoctorSameDatePatients>();

            while (await reader.ReadAsync())
            {
                list.Add(new SameDoctorSameDatePatients
                {
                    DoctorName = reader["DoctorName"]?.ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    TotalPatients = Convert.ToInt32(reader["TotalPatients"])
                });
            }

            return list;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsNext7Days()
        {
            using SqlConnection con = new SqlConnection(_con);
            using SqlCommand cmd = new SqlCommand("sp_AppointmentsNext7Days", con);

            cmd.CommandType = CommandType.StoredProcedure;
            await con.OpenAsync();

            using SqlDataReader reader = await cmd.ExecuteReaderAsync();

            var list = new List<Appointment>();

            while (await reader.ReadAsync())
            {
                list.Add(new Appointment
                {
                    AppointmentId = Convert.ToInt32(reader["AppointmentId"]),
                    PatientName = reader["PatientName"]?.ToString(),
                    DoctorName = reader["DoctorName"]?.ToString(),
                    Specialization = reader["Specialization"]?.ToString(),
                    AppointmentDate = Convert.ToDateTime(reader["AppointmentDate"]),
                    Status = reader["Status"]?.ToString()
                });
            }

            return list;
        }
    }
}