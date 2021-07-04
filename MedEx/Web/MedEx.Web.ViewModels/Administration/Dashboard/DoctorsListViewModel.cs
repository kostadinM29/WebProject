using System;
using System.Collections.Generic;
using System.Text;

namespace MedEx.Web.ViewModels.Administration.Dashboard
{
    public class DoctorsListViewModel
    {
        public IEnumerable<DoctorsInListViewModel> Doctors { get; set; }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < PagesCount;

        public int PreviousPageNumber => PageNumber - 1;

        public int NextPageNumber => PageNumber + 1;

        public int PageNumber { get; set; }

        public int PagesCount => (int)Math.Ceiling((double)DoctorsCount / ItemsPerPage);

        public int DoctorsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}
