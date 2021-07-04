using MedEx.Web.ViewModels.Doctor;

namespace MedEx.Services.Data.Doctors
{
    public interface IDoctorService
    {
        void Create(DoctorApplyInputModel model);
    }
}
