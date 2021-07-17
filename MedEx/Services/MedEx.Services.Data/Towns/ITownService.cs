using MedEx.Web.ViewModels.Administration.TownViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Towns
{
    public interface ITownService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task CreateAsync(TownCreateFormModel model);
    }
}
