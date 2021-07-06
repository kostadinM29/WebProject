using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
