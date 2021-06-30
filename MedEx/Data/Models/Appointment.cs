using System;

namespace MedEx.Data.Models
{
    public class Appointment
    {
        public string Id { get; set; } = new Guid().ToString();

        public DateTime Date { get; set; }

        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
