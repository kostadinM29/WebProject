using System.Collections.Generic;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentsListPatientViewModel
    {
        public IEnumerable<AppointmentViewPatientModel> Appointments { get; set; }
    }
}
