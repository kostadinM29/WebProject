using MedEx.Data.Models;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Specializations
{
    public interface ISpecializationService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task CreateAsync(SpecializationCreateFormModel model);

        Task<T> GetSpecializationByIdAsync<T>(int specializationId);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<bool> EditAsync(int specializationId, string name, string description);

        Task<bool> DeleteAsync(int specializationId);
    }
}
