using MedEx.Services.Data.Specializations;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels;
using MedEx.Web.ViewModels.Index;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedEx.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private readonly ITownService _townService;
        private readonly ISpecializationService _specializationService;

        public HomeController(ITownService townService, ISpecializationService specializationService)
        {
            _townService = townService;
            _specializationService = specializationService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                TownItems = _townService.GetAllAsKeyValuePairs(),
                SpecializationItems = _specializationService.GetAllAsKeyValuePairs()
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
