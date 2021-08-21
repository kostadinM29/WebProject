using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Data.Doctors;
using MedEx.Web.ViewModels.DoctorViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DoctorController : AdministrationController
    {
        private readonly IDoctorService _doctorService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DoctorController(IDoctorService doctorService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _doctorService = doctorService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> Verify(int doctorId, int pageNumber)
        {
            var doctor = _doctorService.GetDoctorById(doctorId);

            var user = _userManager.Users.FirstOrDefault(u => u.Id == doctor.UserId);

            var checkIfDocExists = await _doctorService.VerifyAsync(doctorId, doctor.UserId);

            if (checkIfDocExists == false)
            {
                return new StatusCodeResult(404);
            }

            await _userManager.AddToRoleAsync(user, GlobalConstants.DoctorRoleName);

            //await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction(nameof(AppliedDoctors), new { id = pageNumber });
        }

        [Authorize]
        public async Task<IActionResult> Delete(int doctorId, int pageNumber)
        {
            var checkIfDocExists = await _doctorService.DeleteAsync(doctorId);

            if (checkIfDocExists == false)
            {
                return new StatusCodeResult(404);
            }

            return RedirectToAction(nameof(AppliedDoctors), new { id = pageNumber });
        }
    }
}
