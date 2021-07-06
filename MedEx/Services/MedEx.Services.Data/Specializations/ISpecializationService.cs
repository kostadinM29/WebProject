using System.Collections.Generic;
using System.Threading.Tasks;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;

namespace MedEx.Services.Data.Specializations
{
    public interface ISpecializationService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task CreateAsync(SpecializationCreateInputModel model);
    }
}
