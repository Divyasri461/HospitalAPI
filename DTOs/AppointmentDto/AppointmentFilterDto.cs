namespace HospitalAPI.DTOs.AppointmentDto
{
    public class AppointmentFilterDto
    {
        public int? DoctorId { get; set; }
        public string Status { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}