using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.DTOs
{
    
        public class GetActivePatientDto
        {
            public int PatientId { get; set; }
            public string PatientCode { get; set; }
            public string FullName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string? Email { get; set; }

            public int Age { get; set; }
        }
    }


