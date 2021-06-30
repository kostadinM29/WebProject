using System;
using Microsoft.AspNetCore.Identity;

namespace MedEx.Data.Models
{
    public class User : IdentityUser
    {

        public string Location { get; set; }

        public string Gender { get; set; }

        public DateTime RegisteredOn { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public string PictureId { get; set; }

        public Picture ProfilePicture { get; set; }
    }
}
