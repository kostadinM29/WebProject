using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Ratings
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _ratingRepository;
        private readonly IDeletableEntityRepository<Appointment> _appointmentRepository;

        public RatingService(IRepository<Rating> ratingRepository, IDeletableEntityRepository<Appointment> appointmentRepository)
        {
            _ratingRepository = ratingRepository;
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<T> GetAllRatingsByDoctorId<T>(int doctorId, int count)
        {
            var model = _ratingRepository.AllAsNoTracking()
                .Where(r => r.DoctorId == doctorId)
                .OrderByDescending(d => d.Id)
                .Take(count)
                .To<T>()
                .ToList();

            return model;
        }

        public async Task AddAsync(int appointmentId, int doctorId, int patientId, int number, string comment)
        {
            var appointment = _appointmentRepository.All().First(a => a.Id == appointmentId);

            var rating = new Rating
            {
                AppointmentId = appointmentId,
                Number = number,
                Comment = comment,
                DoctorId = doctorId,
                PatientId = patientId
            };

            appointment.IsRated = true;
            appointment.Rating = rating;

            await _ratingRepository.AddAsync(rating);
            await _ratingRepository.SaveChangesAsync();
        }
    }
}
