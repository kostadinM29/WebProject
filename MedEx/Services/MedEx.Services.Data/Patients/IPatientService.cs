using MedEx.Data.Models;
using MedEx.Web.ViewModels.Administration.PatientViewModels;
using MedEx.Web.ViewModels.PatientViewModels;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Patients
{
    public interface IPatientService
    {
        public Task CreateAsync(PatientCreateFormModel model, string userId);

        Task EditAsync(PatientEditFormModel model);

        Task<int?> GetPatientIdByUserId(string userId);

        T GetPatientById<T>(int patientId);

        Patient GetPatientById(int patientId);
    }
}
