using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedEx.Web.ViewModels.Administration.SpecializationViewModels;
using MedEx.Web.ViewModels.PatientViewModels;

namespace MedEx.Services.Data.Specializations
{
    public class SpecializationService : ISpecializationService
    {
        private readonly IDeletableEntityRepository<Specialization> _specializationsRepository;

        public SpecializationService(IDeletableEntityRepository<Specialization> specializationsRepository)
        {
            _specializationsRepository = specializationsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
             return _specializationsRepository.AllAsNoTracking() // better to use AsNoTracking to save some memory
                 .Select(s => new
                {
                    s.Id,
                    s.Name,
                })
                .ToList()
                .Select(s => new KeyValuePair<string, string>(s.Id.ToString(), s.Name));
        }

        public async Task CreateAsync(SpecializationCreateInputModel model)
        {
            var specialization = new Specialization
            {
                Name = model.Name,
                Description = model.Description
            };

            await _specializationsRepository.AddAsync(specialization);
            await _specializationsRepository.SaveChangesAsync();
        }
    }
}
