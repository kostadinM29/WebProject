using MedEx.Data.Models;
using MedEx.Services.Data.Specializations;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MedEx.Services.Data.Tests
{
    public class SpecializationServiceTests : BaseServiceTests
    {
        private Random Random => new Random();

        private ISpecializationService Service => ServiceProvider.GetRequiredService<ISpecializationService>();

        /*
        Task<T> GetSpecializationByIdAsync<T>(int specializationId);
        Task<IEnumerable<T>> GetAllAsync<T>();
         */
        [Fact]
        public async Task GetAllAsKeyValuePairsShouldReturnCorrectPairs()
        {
            var specialization1 = await CreateSpecializationAsync();
            var specialization2 = await CreateSpecializationAsync();

            var result = Service.GetAllAsKeyValuePairs();

            var correct = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(specialization1.Id.ToString(), "Test"),
                new KeyValuePair<string, string>(specialization2.Id.ToString(), "Test"),
            };
            Assert.Equal(correct, result);
        }

        [Fact]
        public async Task EditAsyncShouldWorkCorrectly()
        {
            var specialization = await CreateSpecializationAsync();

            var result = await Service.EditAsync(specialization.Id, "Test2", "TestTestTestTestTestTestTestTest");
            var result2 = await Service.EditAsync(155, "Test2", "TestTestTestTestTestTestTestTest");

            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public async Task DeleteAsyncShouldWorkCorrectly()
        {
            var specialization = await CreateSpecializationAsync();

            var result = await Service.DeleteAsync(specialization.Id);
            var result2 = await Service.DeleteAsync(155);

            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            await CreateSpecializationAsync();

            var specialization = new SpecializationCreateFormModel()
            {
                Name = "Test1",
                Description = "test test test test test test test test1",
            };

            await Service.CreateAsync(specialization);

            var result = await DbContext.Specializations.CountAsync();

            Assert.Equal(2, result);
        }

        private async Task<Specialization> CreateSpecializationAsync()
        {
            var specialization = new Specialization()
            {
                Name = "Test",
                Description = "test test test test test test test test",
            };

            await DbContext.Specializations.AddAsync(specialization);
            await DbContext.SaveChangesAsync();
            return specialization;
        }
    }
}
