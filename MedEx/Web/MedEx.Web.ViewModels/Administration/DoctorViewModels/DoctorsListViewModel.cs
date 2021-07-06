using System.Collections.Generic;

namespace MedEx.Web.ViewModels.Administration.DoctorViewModels
{
    public class DoctorsListViewModel : PagingViewModel
    {
        public IEnumerable<DoctorsInListViewModel> Doctors { get; set; }
    }
}
