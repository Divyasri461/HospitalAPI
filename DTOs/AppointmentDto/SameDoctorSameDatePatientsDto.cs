namespace HospitalAPI.DTOs.AppointmentDto
{
    public class SameDoctorSameDatePatientsDto
    {
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int TotalPatients { get; set; }
      
    }
}