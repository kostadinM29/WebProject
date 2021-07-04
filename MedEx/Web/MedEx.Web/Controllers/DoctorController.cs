using MedEx.Services.Data.Specializations;
using MedEx.Web.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MedEx.Services.Data.Towns;


namespace MedEx.Web.Controllers
{
    public class DoctorController : BaseController
    {

        private readonly ISpecializationService _specializationService;
        private readonly ITownService _townService;

        public DoctorController(ISpecializationService specializationService, ITownService townService)
        {
            _specializationService = specializationService;
            _townService = townService;
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

        public IActionResult Apply()
        {
            var viewModel = new DoctorApplyInputModel
            {
                TownItems = _townService.GetAllAsKeyValuePairs(),
                SpecializationItems = _specializationService.GetAllAsKeyValuePairs()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Apply(DoctorApplyInputModel model)
        {
            if (!ModelState.IsValid)
            {
                model.TownItems = _townService.GetAllAsKeyValuePairs();
                model.SpecializationItems = _specializationService.GetAllAsKeyValuePairs();
                return View(model);
            }

            model.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Json(model);
            // TODO Redirect to your doctor profile
            //return Redirect("/");
        }
    }
}
