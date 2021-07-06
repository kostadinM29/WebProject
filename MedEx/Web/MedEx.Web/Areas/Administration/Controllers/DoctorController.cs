using MedEx.Common;
using MedEx.Services.Data.Doctors;
using MedEx.Web.ViewModels.Administration.DoctorViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DoctorController : AdministrationController
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        public IActionResult AppliedDoctors(int id)
        {
            var viewModel = new DoctorsListViewModel
            {
                Doctors = _doctorService.GetAllAppliedDoctors<DoctorsInListViewModel>(id,
                    GlobalConstants.AppliedDoctorItemsPerPageCount),
                PageNumber = id,
                ItemsPerPage = GlobalConstants.AppliedDoctorItemsPerPageCount,
                ItemCount = _doctorService.GetAppliedAndNotValidatedDoctorsCount()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Verify(int doctorId, int pageNumber) // id is pageNumber
        {
            var checkIfDocExists = await _doctorService.VerifyAsync(doctorId);

            if (checkIfDocExists == false)
            {
                return NotFound();
            }

            return RedirectToAction("AppliedDoctors", new {id = pageNumber});
        }

        public async Task<IActionResult> Delete(int doctorId, int pageNumber) // id is pageNumber
        {
            var checkIfDocExists = await _doctorService.DeleteAsync(doctorId);

            if (checkIfDocExists == false)
            {
                return NotFound();
            }

            return RedirectToAction("AppliedDoctors", new {id = pageNumber});
        }
    }
}