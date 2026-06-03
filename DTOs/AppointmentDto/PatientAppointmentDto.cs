namespace HospitalAPI.DTOs.AppointmentDto
{
    public class PatientAppointmentDto
    {
        public int AppointmentId { get; set; }

        public string DoctorName { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; }
    }
}