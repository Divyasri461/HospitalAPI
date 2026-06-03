namespace HospitalAPI.DTOs.AppointmentDto
{
    public class DoctorAppointmentCountDto
    {
        public int DoctorId { get; set; }
        public string DoctorCode { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public int TotalAppointments { get; set; }
    }
}