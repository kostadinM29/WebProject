using MedEx.Data.Models;
using MedEx.Services.Data.Home;
using MedEx.Web.ViewModels.HomeViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Xunit;

namespace MedEx.Services.Data.Tests
{
    public class HomeServiceTests : BaseServiceTests
    {
        private IHomeService Service => ServiceProvider.GetRequiredService<IHomeService>();

        /*
            Task<IEnumerable<T>> GetAllFeedbacksAsync<T>();
        */

        [Fact]
        public async Task SolveAsyncShouldSolveCorrectly()
        {
            var feedback = await CreateFeedbackAsync();
            var feedback2 = await CreateFeedbackAsync();

            await Service.SolveAsync(feedback.Id);

            var result = await DbContext.Feedbacks.CountAsync(f => f.IsSolved == true);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            await CreateFeedbackAsync();

            var feedbackModel = new FeedbackCreateFormModel()
            {
                FirstName = "Gosho",
                LastName = "Goshev",
                Email = "gosho@goshev.bg",
                Type = "Site problem",
                Comment = "test test test test test test test test test test test test test test test "
            };

            await Service.CreateAsync(feedbackModel);

            var feedbackCount = await DbContext.Feedbacks.CountAsync();

            Assert.Equal(2, feedbackCount);
        }

        private async Task<Feedback> CreateFeedbackAsync()
        {
            var feedback = new Feedback()
            {
                FirstName = "Gosho",
                LastName = "Goshev",
                Email = "gosho@goshev.bg",
                Type = "Site problem",
                Comment = "test test test test test test test test test test test test test test test "
            };

            await DbContext.Feedbacks.AddAsync(feedback);
            await DbContext.SaveChangesAsync();
            return feedback;
        }
    }
}
