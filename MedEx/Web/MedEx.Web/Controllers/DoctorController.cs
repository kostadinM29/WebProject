using MedEx.Services.Data.Specializations;
using MedEx.Web.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace MedEx.Web.Controllers
{
    public class DoctorController : BaseController
    {

        private readonly ISpecializationService _specializationService;

        public DoctorController(ISpecializationService specializationService)
        {
            _specializationService = specializationService;
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
                SpecializationItems = _specializationService.GetAllAsKeyValuePairs()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Apply(DoctorApplyInputModel model)
        {
            if (!ModelState.IsValid)
            {
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
