using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.Administration.Dashboard;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedEx.Services.Mapping;
using MedEx.Web.ViewModels.DoctorViewModels;

namespace MedEx.Services.Data.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly IDeletableEntityRepository<Doctor> _doctorRepository;


        public DoctorService(IDeletableEntityRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        /*
         * getdoctorId
         *
         * getalldoctors
         *
         * savedoctor
         *
         * updatedoctor
         *
         *
         * getspecializations
         *
         * gettown
         * getaddress
         *
         * savetown
         * updatetown
         *
         * saveaddress
         * updateaddress
         *
         *
         * searchdoctors -- possible multiple methods depending on parameters
         *
         * searchsimilardoctors?
         *
         */
        public async Task CreateAsync(DoctorApplyInputModel model)
        {

            var doctor = new Doctor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Picture = new Picture()
                {
                    ImagePath = model.PictureUrl
                },
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                Experience = model.Experience,
                Email = model.Email,
                Address = model.Address,
                Biography = model.Biography,
                TownId = model.TownId,
                SpecializationId = model.SpecializationId,
                UserId = model.UserId,
                HasApplied = true
            };

            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveChangesAsync();
        }

        public IEnumerable<DoctorsInListViewModel> GetAllAppliedDoctors(int page, int itemsPerPage = 12)
        {
            var model = _doctorRepository.AllAsNoTracking()
                .OrderBy(d => d.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .To<DoctorsInListViewModel>()
                .ToList();

            return model;
        }
    }
}
