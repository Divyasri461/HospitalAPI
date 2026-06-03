using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Required(ErrorMessage ="Doctor Code is Required")]
        [StringLength(20)]
        public string DoctorCode { get; set; }


        [Required(ErrorMessage = "Name is Required")]
        [StringLength(100, MinimumLength = 3)]
      
        public string FullName { get; set; }

        [Required(ErrorMessage = "Specialization is Required")]
        [StringLength(100)]
        public string Specialization { get; set; }
       
        [Required(ErrorMessage = "PhoneNumber is Required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(100)]
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsAvailable { get; set; } = true;
        [Required]
        public decimal ConsultationFee { get; set; }

     
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

    }
}
