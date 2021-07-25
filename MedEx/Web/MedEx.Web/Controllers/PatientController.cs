using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Data.Patients;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.PatientViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedEx.Web.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;
        private readonly ITownService _townService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientController(IPatientService patientService, ITownService townService, UserManager<ApplicationUser> userManager)
        {
            _patientService = patientService;
            _townService = townService;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new PatientCreateFormModel
            {
                TownItems = _townService.GetAllAsKeyValuePairs()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(PatientCreateFormModel input)
        {
            if (!ModelState.IsValid)
            {
                input.TownItems = _townService.GetAllAsKeyValuePairs();
                return View(input);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.FindByIdAsync(userId);

            input.UserId = userId;

            await _patientService.CreateAsync(input, input.UserId);

            await _userManager.AddToRoleAsync(user, GlobalConstants.PatientRoleName);

            // TODO Redirect to your profile
            return Redirect("/");
        }
    }
}
