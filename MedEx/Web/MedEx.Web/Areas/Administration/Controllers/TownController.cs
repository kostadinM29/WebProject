using System.Threading.Tasks;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;
using MedEx.Web.ViewModels.Administration.TownViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class TownController : AdministrationController
    {
        private readonly ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TownCreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            await _townService.CreateAsync(input);

            // TODO Redirect to your profile
            return Redirect("/");
        }
    }
}
