using MedEx.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Rating : BaseModel<int>
    {
        [Required]
        public int Number { get; set; } // 0-10

        public string Comment { get; set; }

        [ForeignKey(nameof(Appointment))]
        public int AppointmentId { get; set; }

        public virtual Appointment Appointment { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
