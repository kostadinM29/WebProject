using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
