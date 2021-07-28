using System.Collections.Generic;
using System.Linq;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.HomeViewModels;
using System.Threading.Tasks;
using MedEx.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MedEx.Services.Data.Home
{
    public class HomeService : IHomeService
    {
        private readonly IDeletableEntityRepository<Feedback> _feedbackRepository;

        public HomeService(IDeletableEntityRepository<Feedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task CreateAsync(FeedbackCreateFormModel model)
        {
            var feedback = new Feedback()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Type = model.Type,
                Comment = model.Comment,
                IsSolved = false
            };

            await _feedbackRepository.AddAsync(feedback);
            await _feedbackRepository.SaveChangesAsync();
        }

        public async Task SolveAsync(int feedbackId)
        {
            var feedback = GetFeedbackById(feedbackId);

            feedback.IsSolved = true;

            await _feedbackRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllFeedbacksAsync<T>() => await _feedbackRepository.All().Where(f => !f.IsSolved.HasValue).To<T>().ToListAsync();

        public Feedback GetFeedbackById(int feedbackId) => _feedbackRepository.All().FirstOrDefault(d => d.Id == feedbackId);
    }
}
