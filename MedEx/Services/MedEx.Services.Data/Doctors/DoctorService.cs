using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.Doctor;

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
        public void Create(DoctorApplyInputModel model)
        {
            var doctor = new Doctor()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                Experience = model.Experience,
            };
        }
    }
}
