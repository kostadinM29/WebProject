using System;
using System.Collections.Generic;

namespace MedEx.Data.Models
{
    public class Doctor
    {
        public string Id { get; set; } = new Guid().ToString();// not sure if to make it int or not

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DoctorType { get; set; }

        public int Phone { get; set; }

        public int Experience { get; set; } // years

        public string Email { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public string Biography { get; set; }

        public string RatingId { get; set; }

        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();

        public string PictureId { get; set; }

        public ICollection<Picture> Pictures { get; set; } = new List<Picture>();

        public string AppointmentId { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
