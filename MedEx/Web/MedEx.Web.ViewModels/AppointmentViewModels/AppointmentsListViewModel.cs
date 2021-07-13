using System.Collections.Generic;

namespace MedEx.Web.ViewModels.AppointmentViewModels
{
    public class AppointmentsListViewModel
    {
        public IEnumerable<AppointmentViewModel> Appointments { get; set; }
    }
}
