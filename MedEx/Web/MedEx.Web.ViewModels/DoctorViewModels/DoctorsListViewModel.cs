using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.DoctorViewModels
{
    public class DoctorsListViewModel : PagingViewModel
    {
        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }

        [Display(Name = "Town")]
        public int? TownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TownItems { get; set; }

        [Display(Name = "Specialization")]
        public int? SpecializationId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> SpecializationItems { get; set; }

        public IEnumerable<DoctorInListViewModel> Doctors { get; set; }
    }
}
