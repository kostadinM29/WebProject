﻿using MedEx.Web.ViewModels.Administration.TownViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedEx.Data.Models;

namespace MedEx.Services.Data.Towns
{
    public interface ITownService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task CreateAsync(TownCreateInputModel model);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<Town> GetTownByIdAsync(int townId);

        Task<T> GetTownByIdAsync<T>(int townId);

        Task<bool> EditAsync(int townId, string name, int? zipCode);

        Task<bool> DeleteAsync(int townId);
    }
}
