using System.ComponentModel.DataAnnotations;
using MedEx.Common.Attributes;

namespace MedEx.Web.ViewModels.Administration.AppointmentViewModels
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
