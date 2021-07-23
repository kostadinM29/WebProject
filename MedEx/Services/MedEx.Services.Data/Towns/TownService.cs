using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using MedEx.Web.ViewModels.Administration.TownViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Towns
{
    public class TownService : ITownService
    {
        private readonly IDeletableEntityRepository<Town> _townRepository;

        public TownService(IDeletableEntityRepository<Town> townRepository)
        {
            _townRepository = townRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return _townRepository.AllAsNoTracking() // better to use AsNoTracking to save some memory
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                })
                .ToList()
                .Select(s => new KeyValuePair<string, string>(s.Id.ToString(), s.Name));
        }

        public async Task CreateAsync(TownCreateInputModel model)
        {
            var specialization = new Town
            {
                Name = model.Name,
                ZipCode = model.ZipCode
            };

            await _townRepository.AddAsync(specialization);
            await _townRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() => await _townRepository.All().To<T>().ToListAsync();

        public Task<Town> GetTownByIdAsync(int townId) => _townRepository.All().FirstOrDefaultAsync(s => s.Id == townId);

        public Task<T> GetTownByIdAsync<T>(int townId) => _townRepository.All().Where(s => s.Id == townId).To<T>().FirstOrDefaultAsync(); // has to track

        public async Task<bool> EditAsync(int townId, string name, int? zipCode)
        {
            var town = await GetTownByIdAsync(townId);

            if (town == null)
            {
                return false;
            }

            town.Name = name;
            town.ZipCode = zipCode;

            _townRepository.Update(town);

            await _townRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int townId) // potential spaghetti code
        {
            var town = await GetTownByIdAsync(townId);

            if (town == null)
            {
                return false;
            }

            _townRepository.Delete(town);

            await _townRepository.SaveChangesAsync();

            return true;
        }
    }
}
