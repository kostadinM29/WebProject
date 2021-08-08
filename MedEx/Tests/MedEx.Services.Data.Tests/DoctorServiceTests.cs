using MedEx.Data.Models;
using MedEx.Services.Data.Doctors;
using MedEx.Web.ViewModels.Administration.DoctorViewModels;
using MedEx.Web.ViewModels.DoctorViewModels;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Image = MedEx.Data.Models.Image;

namespace MedEx.Services.Data.Tests
{
    public class DoctorServiceTests : BaseServiceTests
    {
        private Random Random => new Random();

        private IDoctorService Service => ServiceProvider.GetRequiredService<IDoctorService>();

        /*
           IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage);
           
           IEnumerable<T> GetAllValidatedDoctors<T>(int page, int itemsPerPage, string searchTerm, int? townId, int? specializationId);
           
           IEnumerable<T> GetAllAppliedDoctors<T>(int page, int itemsPerPage);
           
           T GetDoctorByAppointmentId<T>(int appointmentId);
           
           T GetDoctorById<T>(int doctorId);
         */

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var doctor = await CreateDoctorAsync();

            var result = await Service.DeleteAsync(doctor.Id);
            var result2 = await Service.DeleteAsync(4);

            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public async Task VerifyASyncShouldVerifyCorrectly()
        {
            var user = new ApplicationUser()
            {
                UserName = "qwerty",
            };

            var doctor = await CreateDoctorAsync();

            await DbContext.ApplicationUsers.AddAsync(user);
            await DbContext.SaveChangesAsync();

            var result = await Service.VerifyAsync(doctor.Id, user.Id);
            var result2 = await Service.VerifyAsync(4, user.Id);

            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public async Task GetDoctorByIdShouldReturnDoctorIdCorrectly()
        {
            var doctor = await CreateDoctorAsync();

            var result = Service.GetDoctorById(doctor.Id);

            Assert.Equal(doctor, result);
        }

        [Fact]
        public async Task GetDoctorIdByUserIdShouldWorkCorrectly()
        {
            var doctor = await CreateDoctorAsync();

            var userId = Guid.NewGuid().ToString();

            doctor.UserId = userId;
            await DbContext.SaveChangesAsync();

            var result = Service.GetDoctorIdByUserId(userId);

            Assert.Equal(doctor.Id, result);
        }

        [Fact]
        public async Task GetAppliedAndNotValidatedDoctorsCountShouldReturnCorrectly()
        {
            var doctor = await CreateDoctorAsync();
            var doctor2 = await CreateDoctorAsync();

            doctor2.IsValidated = true;

            await DbContext.SaveChangesAsync();

            var notValidatedDoctorsCount = Service.GetAppliedAndNotValidatedDoctorsCount();

            Assert.Equal(1, notValidatedDoctorsCount);
        }

        [Fact]
        public async Task EditAsyncShouldEditCorrectly()
        {
            var doctor = await CreateDoctorAsync();
            var doctor2 = await CreateDoctorAsync();

            var doctorEdit = new DoctorEditFormModel()
            {
                Id = doctor2.Id,
                FirstName = "Johnny",
                LastName = "Bravo",
                Age = Random.Next(99),
                PhoneNumber = Random.Next().ToString(),
                Experience = Random.Next(50),
                Email = "random@random.com",
                Address = "test adress",
                Biography = "test test test test test",
                TownId = 3,
                SpecializationId = 2,
            };

            await Service.EditAsync(doctorEdit, "path");

            doctor2 = await DbContext.Doctors.Where(d => d.TownId == 3).FirstOrDefaultAsync();

            Assert.NotEqual(doctor, doctor2);
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            await CreateDoctorAsync();

            var doctor = new DoctorApplyFormModel()
            {
                FirstName = "Johnny",
                LastName = "Bravo",
                Age = Random.Next(99),
                PhoneNumber = Random.Next().ToString(),
                Experience = Random.Next(50),
                Email = "random@random.com",
                Address = "test address",
                Biography = "test test test test test",
                TownId = 2,
                SpecializationId = 1,
                Image = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.png"),
            };

            await Service.CreateAsync(doctor, "path");

            var doctorsCount = await DbContext.Doctors.CountAsync();
            Assert.Equal(2, doctorsCount);
        }

        private async Task<Doctor> CreateDoctorAsync()
        {
            var doctor = new Doctor()
            {
                Id = Random.Next(500),
                FirstName = "Johnny",
                LastName = "Bravo",
                Age = 51,
                PhoneNumber = "0884343421",
                Experience = 12,
                Email = "random@random.com",
                Address = "test adress",
                Biography = "test test test test test",
                TownId = 2,
                SpecializationId = 1,
                HasApplied = true,
            };

            await DbContext.AddAsync(doctor);
            await DbContext.SaveChangesAsync();
            return doctor;
        }
    }
}
