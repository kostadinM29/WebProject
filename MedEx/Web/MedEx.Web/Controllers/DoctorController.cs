using MedEx.Web.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Controllers
{
    public class DoctorController : BaseController
    {
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
            return View();
        }

        [HttpPost]
        public IActionResult Apply(DoctorApplyInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            //TODO Redirect to your doctor profile
            return Redirect("/");
        }
    }
}
