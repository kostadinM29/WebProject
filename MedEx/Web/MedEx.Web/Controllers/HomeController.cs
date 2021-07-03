using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels;
using MedEx.Web.ViewModels.Index;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace MedEx.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Doctor> _doctorRepository;
        private readonly IRepository<Town> _townRepository;
        private readonly IDeletableEntityRepository<Review> _reviewRepository;

        public HomeController(IDeletableEntityRepository<Doctor> doctorRepository, IDeletableEntityRepository<Review> reviewRepository, IRepository<Town> townRepository)
        {
            _doctorRepository = doctorRepository;
            _reviewRepository = reviewRepository;
            _townRepository = townRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel()
            {
                DoctorCount = _doctorRepository.All().Count(),
                TownCount = _townRepository.All().Count(),
                PositiveReviews = _reviewRepository.All().Count(r => r.Rating > 5), // counting reviews 1-5 as negative and 6-10 as positive
                TotalReviews = _reviewRepository.All().Count(),
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
