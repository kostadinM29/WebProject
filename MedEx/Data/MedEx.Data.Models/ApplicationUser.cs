using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MedEx.Data.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Location { get; set; }

        public string Gender { get; set; }

        public DateTime RegisteredOn { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public string PictureId { get; set; }

        public Picture ProfilePicture { get; set; }

        public string TownId { get; set; }

        public Town Town { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }
            = new HashSet<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }
            = new HashSet<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
            = new HashSet<IdentityUserLogin<string>>();
    }
}
