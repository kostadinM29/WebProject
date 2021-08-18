using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using MedEx.Web.ViewModels.Administration.PatientViewModels;
using MedEx.Web.ViewModels.PatientViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Patients
{
    public class PatientService : IPatientService
    {
        private readonly IDeletableEntityRepository<Patient> _patientRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> _userRepository;

        public PatientService(IDeletableEntityRepository<Patient> patientRepository, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            _patientRepository = patientRepository;
            _userRepository = userRepository;
        }

        public async Task<int?> GetPatientIdByUserId(string userId)
        {
            return await _patientRepository.AllAsNoTracking().Where(p => p.UserId == userId).Select(p => p.Id).FirstOrDefaultAsync();
        }

        public async Task EditAsync(PatientEditFormModel model)
        {
            var patient = _patientRepository.All().FirstOrDefault(d => d.Id == model.Id);

            patient.FirstName = model.FirstName;
            patient.LastName = model.LastName;
            patient.Gender = model.Gender;
            patient.Age = model.Age;
            patient.PhoneNumber = model.PhoneNumber;
            patient.TownId = model.TownId;

            _patientRepository.Update(patient);
            await _patientRepository.SaveChangesAsync();
        }

        public async Task CreateAsync(PatientCreateFormModel model, string userId)
        {
            var patientUser = _userRepository.All().FirstOrDefault(u => u.Id == userId);

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

            patientUser.Patient = patient;

            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveChangesAsync();
        }

        public T GetPatientById<T>(int patientId) => _patientRepository.All().Where(p => p.Id == patientId).To<T>().FirstOrDefault(); // has to track
    }
}
