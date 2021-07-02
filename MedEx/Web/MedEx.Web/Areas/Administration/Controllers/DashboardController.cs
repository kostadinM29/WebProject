using MedEx.Services.Data;
using MedEx.Web.ViewModels.Administration.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;

        public DashboardController(ISettingsService settingsService)
        {
            this.settingsService = settingsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel { SettingsCount = settingsService.GetCount(), };
            return View(viewModel);
        }
    }
}
