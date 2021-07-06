using MedEx.Data.Common.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Doctor : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; } // potentially stationary/telephone

        public int? Experience { get; set; } // years

        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(500)]
        public string Biography { get; set; }

        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        [ForeignKey(nameof(Specialization))]
        public int SpecializationId { get; set; }

        public virtual Specialization Specialization { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public bool HasApplied { get; set; }

        public bool IsValidated { get; set; }
    }
}
