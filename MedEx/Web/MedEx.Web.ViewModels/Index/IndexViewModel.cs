using System;
using System.Collections.Generic;
using System.Text;

namespace MedEx.Web.ViewModels.Index
{
   public class IndexViewModel
    {
        public int DoctorCount { get; set; }

        public int TownCount { get; set; }

        public int PositiveReviews { get; set; }

        public int TotalReviews { get; set; }
    }
}
