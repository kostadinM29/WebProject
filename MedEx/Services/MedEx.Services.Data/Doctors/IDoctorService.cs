using MedEx.Data.Models;
using MedEx.Web.ViewModels.Administration.DoctorViewModels;
using MedEx.Web.ViewModels.DoctorViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Doctors
{
    public interface IDoctorService
    {
        Task EditAsync(DoctorEditFormModel model, string imagePath);

        Task CreateAsync(DoctorApplyFormModel model, string imagePath);

        IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage);

        IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage, string searchTerm, int? townId, int? specializationId);

        IEnumerable<T> GetAllAppliedDoctors<T>(int page, int itemsPerPage);

        int GetAppliedAndNotValidatedDoctorsCount();

        int? GetDoctorIdByUserId(string userId);

        T GetDoctorByAppointmentId<T>(int appointmentId);

        T GetDoctorById<T>(int doctorId);

        Doctor GetDoctorById(int doctorId);

        Task<bool> VerifyAsync(int doctorId, string userId);

        Task<bool> DeleteAsync(int doctorId);
    }
}
