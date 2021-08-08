using MedEx.Web.ViewModels.HomeViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Home
{
    public interface IHomeService
    {
        Task CreateAsync(FeedbackCreateFormModel model);

        Task SolveAsync(int feedbackId);

        Task<IEnumerable<T>> GetAllFeedbacksAsync<T>();
    }
}
