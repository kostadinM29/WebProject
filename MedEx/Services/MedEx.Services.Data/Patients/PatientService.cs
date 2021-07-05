using System.Collections.Generic;
using System.Linq;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.PatientViewModels;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IDeletableEntityRepository<Patient> _patientRepository;

        public PatientService(IDeletableEntityRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        /*
         * getpatientid
         *
         * getallpatients
         *
         *
         * savepatient
         * updatpatient
         *
         * getallpatientappointments
         *
         *
         *
         */
        public async Task CreateAsync(PatientCreateInputModel model)
        {
            var patient = new Patient()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                TownId = model.TownId,
                UserId = model.UserId,
            };

            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveChangesAsync();
        }
    }
}
