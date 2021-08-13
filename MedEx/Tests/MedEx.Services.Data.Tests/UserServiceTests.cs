using MedEx.Services.Data.Users;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MedEx.Services.Data.Tests
{
    public class UserServiceTests : BaseServiceTests
    {
        private Random Random => new Random();

        private IUserService Service => ServiceProvider.GetRequiredService<IUserService>();

        /*
        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();
         */
    }
}
