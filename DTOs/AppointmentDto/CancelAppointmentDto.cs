using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs.AppointmentDto
{
    public class CancelAppointmentDto
    {
        [Required(ErrorMessage = "AppointmentId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "AppointmentId must be greater than 0")]
        public int AppointmentId { get; set; }
    }
}