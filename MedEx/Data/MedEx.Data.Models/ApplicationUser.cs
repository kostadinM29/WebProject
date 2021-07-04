using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new List<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new List<IdentityUserLogin<string>>();
    }
}
