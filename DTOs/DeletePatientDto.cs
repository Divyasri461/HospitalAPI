using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class DeletePatientDto
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PatientId { get; set; }
    }
}