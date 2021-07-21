using MedEx.Services.Data.Patients;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.PatientViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedEx.Web.Controllers
{
    public class PatientController : BaseController
    {
        private readonly IPatientService _patientService;
        private readonly ITownService _townService;

        public PatientController(IPatientService patientService, ITownService townService)
        {
            _patientService = patientService;
            _townService = townService;
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

            input.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _patientService.CreateAsync(input, input.UserId);

            // TODO Redirect to your profile
            return Redirect("/");
        }
    }
}
