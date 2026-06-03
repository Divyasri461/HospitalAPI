using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class UpdatePatientDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression("^(male|female|other)$",
            ErrorMessage = "Gender must be male, female or other")]
        public string Gender { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$",
            ErrorMessage = "Phone number must contain exactly 10 digits")]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }
    }
}