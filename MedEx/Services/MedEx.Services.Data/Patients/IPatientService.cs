using MedEx.Web.ViewModels.PatientViewModels;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Patients
{
    public interface IPatientService
    {
        public Task CreateAsync(PatientCreateFormModel model, string userId);

        int? GetPatientIdByUserId(string userId);
    }
}
