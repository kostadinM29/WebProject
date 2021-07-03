using System.Linq;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.Index;

namespace MedEx.Services.Data.Home
{
    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Doctor> _doctorRepository;
        private readonly IRepository<Town> _townRepository;
        private readonly IDeletableEntityRepository<Review> _reviewRepository;

        public HomeService(IDeletableEntityRepository<Review> reviewRepository, IRepository<Town> townRepository, IDeletableEntityRepository<Doctor> doctorRepository)
        {
            _reviewRepository = reviewRepository;
            _townRepository = townRepository;
            _doctorRepository = doctorRepository;
        }

        public IndexViewModel GetAllCounts()
        {
            var data = new IndexViewModel()
            {
                DoctorCount = _doctorRepository.All().Count(),
                TownCount = _townRepository.All().Count(),
                PositiveReviews = _reviewRepository.All().Count(r => r.Rating > 5), // counting reviews 1-5 as negative and 6-10 as positive
                TotalReviews = _reviewRepository.All().Count(),
            };
            return data;
        }
    }
}
