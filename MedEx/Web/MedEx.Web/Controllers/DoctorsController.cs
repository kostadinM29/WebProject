using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Controllers
{
    public class DoctorsController : BaseController
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
    }
}
