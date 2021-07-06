using MedEx.Web.ViewModels.DoctorViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Doctors
{
    public interface IDoctorService
    {
        Task CreateAsync(DoctorApplyInputModel model);

        IEnumerable<T> GetAllAppliedDoctors<T>(int page, int itemsPerPage);

        int GetAppliedAndNotValidatedDoctorsCount();

        Task<bool> VerifyAsync(int doctorId);

        Task<bool> DeleteAsync(int doctorId);
    }
}
