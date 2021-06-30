using System;

namespace MedEx.Data.Models
{
    public class Reviews
    {
        public string Id { get; set; } = new Guid().ToString();

        public int Rating { get; set; } // 0-10

        public string Comment { get; set; }

        public bool IsPositive { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
