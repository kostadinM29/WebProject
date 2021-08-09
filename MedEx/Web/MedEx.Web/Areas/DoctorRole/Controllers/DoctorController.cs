using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MedEx.Data.Models;
using MedEx.Services.Data.Doctors;
using MedEx.Services.Data.Specializations;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.Administration.DoctorViewModels;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedEx.Web.Areas.DoctorRole.Controllers
{
    public class DoctorController : DoctorRoleController
    {
        private readonly IDoctorService _doctorService;
        private readonly ISpecializationService _specializationService;
        private readonly ITownService _townService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _environment;

        public DoctorController(IDoctorService doctorService, ISpecializationService specializationService, ITownService townService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _doctorService = doctorService;
            _specializationService = specializationService;
            _townService = townService;
            _userManager = userManager;
            _environment = environment;
        }

        [Authorize]
        public async Task<IActionResult> Edit() // need to make sure that user cant edit other doctors profiles
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            var doctorId = user.DoctorId;

            var viewModel = _doctorService.GetDoctorById<DoctorEditFormModel>(doctorId.Value);

            viewModel.Id = doctorId.Value;
            viewModel.TownItems = _townService.GetAllAsKeyValuePairs();
            viewModel.SpecializationItems = _specializationService.GetAllAsKeyValuePairs();

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(DoctorEditFormModel input)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _doctorService.GetDoctorById<DoctorEditFormModel>(input.Id);

                viewModel.Id = input.Id;
                viewModel.TownItems = _townService.GetAllAsKeyValuePairs();
                viewModel.SpecializationItems = _specializationService.GetAllAsKeyValuePairs();
                return View(viewModel);
            }

            try
            {
                await _doctorService.EditAsync(input, _environment.WebRootPath);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

                var viewModel = _doctorService.GetDoctorById<DoctorEditFormModel>(input.Id);

                viewModel.Id = input.Id;
                viewModel.TownItems = _townService.GetAllAsKeyValuePairs();
                viewModel.SpecializationItems = _specializationService.GetAllAsKeyValuePairs();
                return View(viewModel);
            }

            return Redirect("/");
        }
    }
}
