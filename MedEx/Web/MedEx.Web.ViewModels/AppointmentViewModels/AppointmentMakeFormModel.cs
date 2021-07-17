using MedEx.Web.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentMakeFormModel
    {
        [Required]
        [ValidateDateString]
        public string Date { get; set; }

        [Required]
        [ValidateTimeString]
        public string Time { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int PatientId { get; set; }
    }
}
