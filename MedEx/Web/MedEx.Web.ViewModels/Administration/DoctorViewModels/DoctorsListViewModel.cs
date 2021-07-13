using System.Collections.Generic;

namespace MedEx.Web.ViewModels.Administration.DoctorViewModels
{
    public class DoctorsListViewModel : PagingViewModel
    {
        public IEnumerable<DoctorInListViewModel> Doctors { get; set; }
    }
}
