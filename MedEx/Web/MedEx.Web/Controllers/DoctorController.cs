using MedEx.Services.Data.Specializations;
using MedEx.Services.Data.Towns;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using MedEx.Services.Data.Doctors;
using MedEx.Web.ViewModels.DoctorViewModels;
using Microsoft.AspNetCore.Authorization;


namespace MedEx.Web.Controllers
{
    public class DoctorController : BaseController
    {

        private readonly ISpecializationService _specializationService;
        private readonly ITownService _townService;
        private readonly IDoctorService _doctorService;

        public DoctorController(ISpecializationService specializationService, ITownService townService,IDoctorService doctorService)
        {
            _specializationService = specializationService;
            _townService = townService;
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            /*
             * possibly add pages?
             *
             * search by town/specialization
             */
            return View();
        }
        [Authorize]
        public IActionResult Apply()
        {
            var viewModel = new DoctorApplyInputModel
            {
                TownItems = _townService.GetAllAsKeyValuePairs(),
                SpecializationItems = _specializationService.GetAllAsKeyValuePairs()
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Apply(DoctorApplyInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TownItems = _townService.GetAllAsKeyValuePairs();
                model.SpecializationItems = _specializationService.GetAllAsKeyValuePairs();
                return View(model);
            }

            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _doctorService.CreateAsync(model);

            // TODO Redirect to your doctor profile
            return Redirect("/");
        }
    }
}
