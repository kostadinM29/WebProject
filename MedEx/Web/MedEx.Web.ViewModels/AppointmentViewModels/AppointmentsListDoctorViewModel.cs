using System.Collections.Generic;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentsListDoctorViewModel
    {
        public IEnumerable<AppointmentViewDoctorModel> Appointments { get; set; }
    }
}
