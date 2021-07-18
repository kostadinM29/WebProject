using MedEx.Web.ViewModels.DoctorViewModels;
using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentRateFormModel
    {
        [Required]
        [Range(1, 5)]
        [Display(Name = "Rating")]
        public int Number { get; set; }

        [MaxLength(50)]
        public string Comment { get; set; }

        public int AppointmentId { get; set; }

        public DoctorSimplifiedViewModel Doctor { get; set; }

        public int DoctorId { get; set; }

        public int PatientId { get; set; }
    }
}
