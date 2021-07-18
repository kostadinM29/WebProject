using MedEx.Web.ViewModels.RatingViewModels;
using System.Collections.Generic;

namespace MedEx.Web.ViewModels.DoctorViewModels
{
    public class DoctorProfileViewModel
    {
        public IEnumerable<RatingViewModel> Ratings { get; set; }

        public DoctorInListViewModel Doctor { get; set; }
    }
}
