namespace HospitalAPI.DTOs.AppointmentDto
{
    public class DoctorAppointmentDto
    {
        public int AppointmentId { get; set; }

        public string PatientName { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; }
    }
}