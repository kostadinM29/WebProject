using System;
using MedEx.Services.Data.Ratings;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MedEx.Data.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MedEx.Services.Data.Tests
{
    public class RatingServiceTests : BaseServiceTests
    {
        private IRatingService Service => ServiceProvider.GetRequiredService<IRatingService>();

        /*
        IEnumerable<T> GetAllRatingsByDoctorId<T>(int doctorId, int count);
         */

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            var appointment = new Appointment()
            {
                PatientId = 1,
                DoctorId = 1,
                DateTime = DateTime.UtcNow.AddDays(-3),
                IsRated = false,
            };

            await DbContext.Appointments.AddAsync(appointment);
            await DbContext.SaveChangesAsync();

            await Service.AddAsync(1, 1, 1, 5, "Nice");

            var result = await DbContext.Ratings.CountAsync();

            Assert.Equal(1, result);
        }
    }
}
