using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Data.Doctors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using MedEx.Web.ViewModels.DoctorViewModels;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DoctorController : AdministrationController
    {
        private readonly IDoctorService _doctorService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorController(IDoctorService doctorService, UserManager<ApplicationUser> userManager)
        {
            _doctorService = doctorService;
            _userManager = userManager;
        }

        public IActionResult AppliedDoctors(int id)
        {
            var viewModel = new DoctorsListViewModel
            {
                Doctors = _doctorService.GetAllAppliedDoctors<DoctorInListViewModel>(id, GlobalConstants.AppliedDoctorItemsPerPageCount),
                PageNumber = id,
                ItemsPerPage = GlobalConstants.AppliedDoctorItemsPerPageCount,
                ItemCount = _doctorService.GetAppliedAndNotValidatedDoctorsCount()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Verify(int doctorId, int pageNumber) // id is pageNumber
        {
            var doctor = _doctorService.GetDoctorById(doctorId);

            var user = _userManager.Users.FirstOrDefault(u => u.Id == doctor.UserId);

            await _userManager.AddToRoleAsync(user, GlobalConstants.DoctorRoleName);

            var checkIfDocExists = await _doctorService.VerifyAsync(doctorId);

            if (checkIfDocExists == false)
            {
                return NotFound();
            }

            return RedirectToAction("AppliedDoctors", new { id = pageNumber });
        }

        public async Task<IActionResult> Delete(int doctorId, int pageNumber) // id is pageNumber
        {
            var checkIfDocExists = await _doctorService.DeleteAsync(doctorId);

            if (checkIfDocExists == false)
            {
                return NotFound();
            }

            return RedirectToAction("AppliedDoctors", new { id = pageNumber });
        }
    }
}
