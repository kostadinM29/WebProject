using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.DoctorRole.Controllers
{
    public class DashboardController : DoctorRoleController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
