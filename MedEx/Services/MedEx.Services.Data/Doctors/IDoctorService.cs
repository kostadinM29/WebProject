using MedEx.Data.Models;
using MedEx.Web.ViewModels.DoctorViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Doctors
{
    public interface IDoctorService
    {
        Task CreateAsync(DoctorApplyInputModel model, string imagePath);

        IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage, string searchTerm, int? townId, int? specializationId);

        IEnumerable<T> GetAllAppliedDoctors<T>(int page, int itemsPerPage);

        int GetValidatedDoctorsCount();

        int GetAppliedAndNotValidatedDoctorsCount();

        Doctor GetDoctorById(int doctorId);

        Task<bool> VerifyAsync(int doctorId);

        Task<bool> DeleteAsync(int doctorId);
    }
}
