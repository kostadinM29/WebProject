using System.Threading.Tasks;
using MedEx.Web.ViewModels.Doctor;

namespace MedEx.Services.Data.Doctors
{
    public interface IDoctorService
    {
        Task CreateAsync(DoctorApplyInputModel model);
    }
}
