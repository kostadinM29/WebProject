using MedEx.Web.ViewModels.DoctorViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedEx.Data.Models;

namespace MedEx.Services.Data.Doctors
{
    public interface IDoctorService
    {
        Task CreateAsync(DoctorApplyInputModel model, string imagePath);

        IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllAppliedDoctors<T>(int page, int itemsPerPage);

        int GetAppliedAndNotValidatedDoctorsCount();

        Doctor GetDoctorById(int doctorId);

        Task<bool> VerifyAsync(int doctorId);

        Task<bool> DeleteAsync(int doctorId);
    }
}
