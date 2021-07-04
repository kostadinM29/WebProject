using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.Doctor
{
    public class DoctorApplyInputModel
    {
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Range(18, 99)]
        public int Age { get; set; }

        [MinLength(6)]
        public string PhoneNumber { get; set; } // potentially stationary/telephone

        public int? Experience { get; set; } // years

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        [Required]
        public string Town { get; set; }

        public string Biography { get; set; }

        public string Specialization { get; set; }

        public string UserId { get; set; } // not sure if needed
    }
}
