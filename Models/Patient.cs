using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
namespace HospitalAPI.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required(ErrorMessage="Patient Code is Required")]
        [StringLength(20)]
        public string PatientCode { get; set; }


        [Required(ErrorMessage = "FullName is Required")]
        [StringLength(100,MinimumLength=3)]
        public string FullName { get; set; }


        [Required(ErrorMessage = "DOB is Required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        [StringLength(10)]
        public string Gender { get; set; }
        [Required(ErrorMessage = "PhoneNumber is Required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set;}


        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt {get;set;}

        public int GetAge()
        {
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateTime.Today < DateOfBirth.AddYears(age)) 
            {
                age--;
            }
            return age;
           
        } 

        }


    }

