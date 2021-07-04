﻿using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
