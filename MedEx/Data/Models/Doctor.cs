using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedEx.Data.Models
{
    public class Doctor
    {
        public string Id { get; set; } 

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DoctorType { get; set; }

        public int Phone { get; set; } // potentially stationary/telephone

        public int Experience { get; set; } // years

        public string Email { get; set; }

        public string TownId { get; set; }

        public Town Town { get; set; }

        public string Address { get; set; }

        public string Biography { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public ICollection<Picture> Pictures { get; set; } = new List<Picture>();

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<ApplicationUser> Clients { get; set; } = new List<ApplicationUser>();

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
