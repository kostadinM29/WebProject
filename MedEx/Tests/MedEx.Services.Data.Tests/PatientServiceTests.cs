using MedEx.Data.Models;
using MedEx.Services.Data.Patients;
using MedEx.Web.ViewModels.Administration.PatientViewModels;
using MedEx.Web.ViewModels.PatientViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MedEx.Services.Data.Tests
{
    public class PatientServiceTests : BaseServiceTests
    {
        private IPatientService Service => ServiceProvider.GetRequiredService<IPatientService>();

        /*
        T GetPatientById<T>(int patientId);
         */
        [Fact]
        public async Task GetPatientIdByUserIdShouldWorkCorrectly()
        {
            var patient = await CreatePatientAsync();

            var userId = Guid.NewGuid().ToString();

            patient.UserId = userId;
            await DbContext.SaveChangesAsync();

            var result = await Service.GetPatientIdByUserId(userId);

            Assert.Equal(patient.Id, result);
        }

        [Fact]
        public async Task EditAsyncShouldEditCorrectly()
        {
            var patient = await CreatePatientAsync();
            var patient2 = await CreatePatientAsync();

            var patientEdit = new PatientEditFormModel()
            {
                Id = patient2.Id,
                FirstName = "Bravo",
                LastName = "Johnny",
                Age = 15,
                Gender = "Male",
                PhoneNumber = "0884343421",
                TownId = 2,
            };

            await Service.EditAsync(patientEdit);

            patient2 = await DbContext.Patients.Where(p => p.Age == 15).FirstOrDefaultAsync();

            Assert.NotEqual(patient, patient2);
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            await CreatePatientAsync();

            var user = new ApplicationUser()
            {
                Id = "testId"
            };

            await DbContext.ApplicationUsers.AddAsync(user);
            await DbContext.SaveChangesAsync();

            var patient = new PatientCreateFormModel()
            {
                FirstName = "Johnny",
                LastName = "Bravo",
                Age = 51,
                Gender = "Male",
                PhoneNumber = "0884343421",
                TownId = 2,
            };

            await Service.CreateAsync(patient, user.Id);

            var result = await DbContext.Patients.CountAsync();

            Assert.Equal(2, result);
        }

        private async Task<Patient> CreatePatientAsync()
        {
            var patient = new Patient()
            {
                FirstName = "Johnny",
                LastName = "Bravo",
                Age = 51,
                Gender = "Male",
                PhoneNumber = "0884343421",
                TownId = 2,
            };

            await DbContext.Patients.AddAsync(patient);
            await DbContext.SaveChangesAsync();
            return patient;
        }
    }
}
