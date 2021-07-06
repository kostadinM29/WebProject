using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Web.ViewModels.Administration.TownViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Towns
{
    public class TownService : ITownService
    {
        private readonly IRepository<Town> _townRepository;

        public TownService(IRepository<Town> townRepository)
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
    }
}
