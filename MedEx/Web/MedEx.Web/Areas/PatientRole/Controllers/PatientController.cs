using MedEx.Data.Models;
using MedEx.Services.Data.Patients;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.Administration.PatientViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedEx.Web.Areas.PatientRole.Controllers
{
    public class PatientController : PatientRoleController
    {
        private readonly ITownService _townService;
        private readonly IPatientService _patientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientController(ITownService townService, IPatientService patientService, UserManager<ApplicationUser> userManager)
        {
            _townService = townService;
            _patientService = patientService;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

            var patientId = user.PatientId;

            var viewModel = _patientService.GetPatientById<PatientEditFormModel>(patientId.Value);

            viewModel.TownItems = _townService.GetAllAsKeyValuePairs();

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(PatientEditFormModel input)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _patientService.GetPatientById<PatientEditFormModel>(input.Id);

                viewModel.TownItems = _townService.GetAllAsKeyValuePairs();
                return View(input);
            }

            await _patientService.EditAsync(input);

            // TODO Redirect to your profile
            return Redirect("/");
        }
    }
}
