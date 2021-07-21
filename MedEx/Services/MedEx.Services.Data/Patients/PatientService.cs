using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.PatientViewModels;
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

        public int? GetPatientIdByUserId(string userId)
        {
            return _patientRepository.AllAsNoTracking().FirstOrDefault(p => p.UserId == userId)?.Id;
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
    }
}
