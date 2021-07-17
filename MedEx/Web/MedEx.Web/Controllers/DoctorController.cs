using MedEx.Common;
using MedEx.Services.Data.Doctors;
using MedEx.Services.Data.Specializations;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.DoctorViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedEx.Web.Controllers
{
    public class DoctorController : BaseController
    {
        private readonly ISpecializationService _specializationService;
        private readonly ITownService _townService;
        private readonly IDoctorService _doctorService;
        private readonly IWebHostEnvironment _environment;

        public DoctorController(ISpecializationService specializationService, ITownService townService, IDoctorService doctorService, IWebHostEnvironment environment)
        {
            _specializationService = specializationService;
            _townService = townService;
            _doctorService = doctorService;
            _environment = environment;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult All(int id, [FromQuery] string searchTerm, int? townId, int? specializationId)
        {
            var viewModel = new DoctorsListViewModel
            {
                TownItems = _townService.GetAllAsKeyValuePairs(),
                SpecializationItems = _specializationService.GetAllAsKeyValuePairs(),
                PageNumber = id,
                ItemsPerPage = GlobalConstants.VerifiedDoctorItemsPerPageCount,
                SearchTerm = searchTerm,
                TownId = townId,
                SpecializationId = specializationId
            };

            if (searchTerm != null || townId != null || specializationId != null)
            {
                viewModel.Doctors = _doctorService.GetAllValidatedDoctors<DoctorInListViewModel>(id, GlobalConstants.VerifiedDoctorItemsPerPageCount, searchTerm, townId, specializationId);
            }
            else
            {
                viewModel.Doctors = _doctorService.GetAllValidatedDoctors<DoctorInListViewModel>(id, GlobalConstants.VerifiedDoctorItemsPerPageCount);
            }

            viewModel.ItemCount = viewModel.Doctors.Count();

            return View(viewModel);
        }

        [Authorize]
        public IActionResult Apply()
        {
            var viewModel = new DoctorApplyFormModel
            {
                TownItems = _townService.GetAllAsKeyValuePairs(),
                SpecializationItems = _specializationService.GetAllAsKeyValuePairs()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Apply(DoctorApplyFormModel input)
        {
            if (!ModelState.IsValid)
            {
                input.TownItems = _townService.GetAllAsKeyValuePairs();
                input.SpecializationItems = _specializationService.GetAllAsKeyValuePairs();
                return View(input);
            }

            input.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            try
            {
                await _doctorService.CreateAsync(input, $"{_environment.WebRootPath}/img");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.TownItems = _townService.GetAllAsKeyValuePairs();
                input.SpecializationItems = _specializationService.GetAllAsKeyValuePairs();
                return View(input);
            }

            // TODO Redirect to your doctor profile
            return Redirect("/");
        }
    }
}
