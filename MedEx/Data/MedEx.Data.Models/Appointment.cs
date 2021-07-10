using MedEx.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Appointment : BaseDeletableModel<int>
    {
        public DateTime DateTime { get; set; }

        public string Date { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public bool? Confirmed { get; set; }
    }
}
