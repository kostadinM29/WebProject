using System.Collections.Generic;

namespace MedEx.Web.ViewModels.Administration.AppointmentViewModels
{
    public class AppointmentsListDoctorViewModel
    {
        public IEnumerable<AppointmentViewDoctorModel> Appointments { get; set; }

        public IEnumerable<AppointmentViewDoctorModel> PastAppointments { get; set; }
    }
}
