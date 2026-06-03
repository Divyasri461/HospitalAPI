using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs.DoctorDto
{
    public class CreateDoctorDto
    {
        [Required(ErrorMessage = "Doctor Code is required")]
        [StringLength(20, ErrorMessage = "Doctor Code cannot exceed 20 characters")]
        public string DoctorCode { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 3,
            ErrorMessage = "Full Name must be between 3 and 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        [StringLength(100,
            ErrorMessage = "Specialization cannot exceed 100 characters")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "Phone number must contain exactly 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Consultation Fee is required")]
        [Range(1, 100000,
            ErrorMessage = "Consultation Fee must be greater than 0")]
        public decimal ConsultationFee { get; set; }

        [Required]
        public bool IsAvailable { get; set; } = true;
    }
}