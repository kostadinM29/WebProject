using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Location { get; set; }

        public string Gender { get; set; }

        public DateTime RegisteredOn { get; set; }

        [ForeignKey(nameof(Picture))]
        public int PictureId { get; set; }

        public virtual Picture Picture { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new List<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new List<IdentityUserLogin<string>>();
    }
}
