using System.ComponentModel.DataAnnotations.Schema;
using MedEx.Data.Common.Models;

namespace MedEx.Data.Models
{
    public class Appointment : BaseDeletableModel<int>
    {
        public string VisitingTime { get; set; }

        public string Date { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

    }
}
