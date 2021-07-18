using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;

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

            _appointmentRepository.All().First(a => a.Id == appointmentId).IsRated = true;

            await _ratingRepository.SaveChangesAsync();
        }
    }
}
