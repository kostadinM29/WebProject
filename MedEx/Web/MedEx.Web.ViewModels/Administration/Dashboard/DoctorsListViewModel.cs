using System;
using System.Collections.Generic;
using System.Text;

namespace MedEx.Web.ViewModels.Administration.Dashboard
{
    public class DoctorsListViewModel
    {
        public IEnumerable<DoctorsInListViewModel> Doctors { get; set; }

        public int PageNumber { get; set; }
    }
}
