using MedEx.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using MedEx.Data;
using MedEx.Web.ViewModels.Index;

namespace MedEx.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ApplicationDbContext _data;

        public HomeController(ApplicationDbContext data)
        {
            this._data = data;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                DoctorCount = _data.Doctors.Count(),
                TownCount = _data.Towns.Count(),
                PositiveReviews = _data.Reviews.Count(r => r.Rating > 5), // counting reviews 1-5 as negative and 6-10 as positive
                TotalReviews = _data.Reviews.Count(),
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
