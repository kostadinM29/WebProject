using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace MedEx.Services.Data
{
    public class SettingsService : ISettingsService
    {
        private readonly IDeletableEntityRepository<Setting> _settingsRepository;

        public SettingsService(IDeletableEntityRepository<Setting> settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public int GetCount()
        {
            return _settingsRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return _settingsRepository.All().To<T>().ToList();
        }
    }
}
