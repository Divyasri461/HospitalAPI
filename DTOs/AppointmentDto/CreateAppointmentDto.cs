using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs.AppointmentDto
{
    public class CreateAppointmentDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PatientId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }
    }
}