namespace HospitalAPI.Models
{
    public class SameDoctorSameDatePatients
    {
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int TotalPatients { get; set; }

    }
}