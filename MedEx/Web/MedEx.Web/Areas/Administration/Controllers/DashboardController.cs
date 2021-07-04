using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.Administration.Dashboard;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MedEx.Web.Areas.Administration.Controllers
{
    public class DashboardController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Doctor> _doctorRepository;
        private readonly IDeletableEntityRepository<Specialization> _specializationRepository;
        private readonly IRepository<Town> _townRepository;
        private readonly IDeletableEntityRepository<Picture> _pictureRepository;

        public DashboardController(IDeletableEntityRepository<Doctor> doctorRepository, IDeletableEntityRepository<Specialization> specializationRepository, IRepository<Town> townRepository, IDeletableEntityRepository<Picture> pictureRepository)
        {
            _doctorRepository = doctorRepository;
            _specializationRepository = specializationRepository;
            _townRepository = townRepository;
            _pictureRepository = pictureRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllDoctors()
        {
            var model = _doctorRepository.All()
                .Select(d => new AllDoctorsViewModel
                {
                    FullName = d.FirstName + " " + d.LastName,
                    PictureUrl = _pictureRepository.AllAsNoTracking().FirstOrDefault(p => p.Id == d.PictureId).ImagePath,
                    Age = d.Age,
                    PhoneNumber = d.PhoneNumber,
                    Experience = d.Experience,
                    Address = d.Address,
                    Email = d.Email,
                    Biography = d.Biography,
                    Town = _townRepository.AllAsNoTracking().FirstOrDefault(t => t.Id == d.TownId).Name,
                    Specialization = _specializationRepository.AllAsNoTracking()
                        .FirstOrDefault(s => s.Id == d.SpecializationId).Name,
                    HasApplied = d.HasApplied
                })
                .ToList();

            return View(model);
        }
    }
}
