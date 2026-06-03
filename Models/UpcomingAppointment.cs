namespace HospitalAPI.Models
{
    public class UpcomingAppointment
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string Specialization { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }
}