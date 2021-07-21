using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Messages
{
    public interface IMessageService
    {
        Task CreateAsync(string content, string authorId, string receiverId);

        Task<string> GetLastActivityAsync(string currentUserId, string userId);

        Task<string> GetLastMessageAsync(string currentUserId, string userId);

        Task<IEnumerable<TModel>> GetAllWithUserAsync<TModel>(string currentUserId, string userId);

        Task<IEnumerable<TModel>> GetAllAsync<TModel>(string currentUserId);
    }
}
