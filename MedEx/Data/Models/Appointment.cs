using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Appointment
    {
        public string Id { get; set; }

        public string VisitingTime { get; set; }

        public string Date { get; set; }

        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
