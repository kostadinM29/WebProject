using System;
using System.Linq;
using System.Threading.Tasks;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;

namespace MedEx.Services.Data.Ratings
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Rating> _ratingRepository;

        public RatingService(IRepository<Rating> ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task AddAsync(int appointmentId, int doctorId, int patientId, int number, string comment)
        {
            await _ratingRepository.AddAsync(new Rating
            {
                AppointmentId = appointmentId,
                Number = number,
                Comment = comment,
                DoctorId = doctorId,
                PatientId = patientId
            });

            await _ratingRepository.SaveChangesAsync();
        }
    }
}
