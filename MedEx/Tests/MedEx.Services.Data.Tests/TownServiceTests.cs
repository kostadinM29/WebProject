using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedEx.Data.Models;
using MedEx.Services.Data.Towns;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;
using MedEx.Web.ViewModels.Administration.TownViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace MedEx.Services.Data.Tests
{
    public class TownServiceTests : BaseServiceTests
    {
        private Random Random => new Random();

        private ITownService Service => ServiceProvider.GetRequiredService<ITownService>();

        /*
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetTownByIdAsync<T>(int townId);
         */
        [Fact]
        public async Task GetAllAsKeyValuePairsShouldReturnCorrectPairs()
        {
            var town1 = await CreateTownAsync();
            var town2 = await CreateTownAsync();

            var result = Service.GetAllAsKeyValuePairs();

            var correct = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>(town1.Id.ToString(), "Test"),
                new KeyValuePair<string, string>(town2.Id.ToString(), "Test"),
            };
            Assert.Equal(correct, result);
        }

        [Fact]
        public async Task EditAsyncShouldWorkCorrectly()
        {
            var town = await CreateTownAsync();

            var result = await Service.EditAsync(town.Id, "Test1", 12345);
            var result2 = await Service.EditAsync(155, "Test2", 12345);

            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public async Task DeleteAsyncShouldWorkCorrectly()
        {
            var town = await CreateTownAsync();

            var result = await Service.DeleteAsync(town.Id);
            var result2 = await Service.DeleteAsync(155);

            Assert.True(result);
            Assert.False(result2);
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            await CreateTownAsync();

            var town = new TownCreateFormModel()
            {
                Name = "Test1",
                ZipCode = 12345
            };

            await Service.CreateAsync(town);

            var result = await DbContext.Towns.CountAsync();

            Assert.Equal(2, result);
        }

        private async Task<Town> CreateTownAsync()
        {
            var town = new Town()
            {
                Name = "Test",
                ZipCode = 1234
            };

            await DbContext.Towns.AddAsync(town);
            await DbContext.SaveChangesAsync();
            return town;
        }
    }
}
