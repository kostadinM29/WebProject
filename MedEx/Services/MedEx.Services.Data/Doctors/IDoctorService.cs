﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MedEx.Web.ViewModels.Administration.Dashboard;
using MedEx.Web.ViewModels.DoctorViewModels;

namespace MedEx.Services.Data.Doctors
{
    public interface IDoctorService
    {
        Task CreateAsync(DoctorApplyInputModel model);

        IEnumerable<DoctorsInListViewModel> GetAllAppliedDoctors(int page, int itemsPerPage);
    }
}
