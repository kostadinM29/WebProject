using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Users
{
    public interface IUserService
    {
        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        string GetByIdByDoctorIdAsync(int id);

        string GetByIdByPatientIdAsync(int id);
    }
}
