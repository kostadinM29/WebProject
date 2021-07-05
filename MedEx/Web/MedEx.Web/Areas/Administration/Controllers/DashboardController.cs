using MedEx.Common;
using MedEx.Services.Data.Doctors;
using MedEx.Web.ViewModels.Administration.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        private readonly IDoctorService _doctorService;

        public DashboardController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AppliedDoctors(int id)
        {
            var viewModel = new DoctorsListViewModel
            {
                Doctors = _doctorService.GetAllAppliedDoctors<DoctorsInListViewModel>(id, GlobalConstants.AppliedDoctorItemsPerPageCount),
                PageNumber = id,
                ItemsPerPage = GlobalConstants.AppliedDoctorItemsPerPageCount,
                DoctorsCount = _doctorService.GetAppliedDoctorsCount()
            };

            return View(viewModel);
        }
    }
}
