namespace HospitalAPI.Models
{
    public class DoctorAppointmentCount
    {
        public int DoctorId { get; internal set; }
        public string? DoctorName { get; internal set; }
        public int TotalAppointments { get; internal set; }
        public string? DoctorCode { get; internal set; }
        public string? Specialization { get; internal set; }
    }
}