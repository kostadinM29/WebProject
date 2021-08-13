using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.Administration.TownViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class TownController : AdministrationController
    {
        private readonly ITownService _townService;

        public TownController(ITownService townService)
        {
            _townService = townService;
        }

        public async Task<IActionResult> All()
        {
            var viewModel = await _townService.GetAllAsync<TownViewModel>();

            return View(viewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(TownCreateFormModel input)
        {
            if (!ModelState.IsValid)
            {
                return View(input);
            }

            await _townService.CreateAsync(input);

            // TODO Redirect to your profile
            return Redirect("/");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int specializationId) // id is pageNumber
        {
            var checkIfSpecExists = await _townService.DeleteAsync(specializationId);

            if (checkIfSpecExists == false)
            {
                return new StatusCodeResult(404);
            }

            return RedirectToAction(nameof(All));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int specializationId)
        {
            var viewModel = await _townService.GetTownByIdAsync<TownEditFormModel>(specializationId);

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(TownEditFormModel input)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Edit), new { input.Id });
            }

            var checkIfSpecExists = await _townService.EditAsync(input.Id, input.Name, input.ZipCode);

            if (checkIfSpecExists == false)
            {
                return new StatusCodeResult(404);
            }

            return RedirectToAction(nameof(All));
        }
    }
}
