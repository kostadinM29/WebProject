using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MedEx.Data;
using MedEx.Data.Models;
using MedEx.Services.Data.Specializations;
using MedEx.Web.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;


namespace MedEx.Web.Controllers
{
    public class DoctorController : BaseController
    {

        private readonly ISpecializationService _specializationService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public DoctorController(ISpecializationService specializationService, UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
        {
            _specializationService = specializationService;
            _userManager = userManager;
            _dbContext = dbContext;
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

        private string GetCurrentUserId() => _userManager.GetUserId(HttpContext.User);

    }
}
