using System.Collections.Generic;

namespace MedEx.Web.ViewModels.Administration.AppointmentViewModels
{
    public class AppointmentsListPatientViewModel
    {
        public IEnumerable<AppointmentViewPatientModel> Appointments { get; set; }

        public IEnumerable<AppointmentViewPatientModel> PastAppointments { get; set; }
    }
}
