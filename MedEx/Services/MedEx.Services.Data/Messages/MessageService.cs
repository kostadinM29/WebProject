using MedEx.Common;
using MedEx.Data.Common.Repositories;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Services.Data.Messages
{
    public class MessageService : IMessageService
    {
        private readonly IDeletableEntityRepository<Message> _messageRepository;

        public MessageService(IDeletableEntityRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task CreateAsync(string content, string senderId, string receiverId)
        {
            var message = new Message
            {
                Content = content,
                SenderId = senderId,
                ReceiverId = receiverId,
            };

            await _messageRepository.AddAsync(message);
            await _messageRepository.SaveChangesAsync();
        }

        public async Task<string> GetLastActivityAsync(string currentUserId, string userId)
            => await _messageRepository.AllAsNoTracking()
                .Where(m => !m.IsDeleted &&
                            ((m.ReceiverId == currentUserId && m.SenderId == userId) ||
                             (m.ReceiverId == userId && m.SenderId == currentUserId)))
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => m.CreatedOn.AddHours(3).ToString(GlobalConstants.DateTimeFormats.DateTimeFormat))
                .FirstOrDefaultAsync();

        public async Task<string> GetLastMessageAsync(string currentUserId, string userId)
            => await _messageRepository.AllAsNoTracking()
                .Where(m => !m.IsDeleted &&
                            ((m.ReceiverId == currentUserId && m.SenderId == userId) ||
                             (m.ReceiverId == userId && m.SenderId == currentUserId)))
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => m.Content)
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<T>> GetAllWithUserAsync<T>(string currentUserId, string userId)
            => await _messageRepository.AllAsNoTracking()
                .Where(m => !m.IsDeleted &&
                            ((m.ReceiverId == currentUserId && m.SenderId == userId) ||
                             (m.ReceiverId == userId && m.SenderId == currentUserId)))
                .OrderBy(m => m.CreatedOn)
                .To<T>()
                .ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync<T>(string currentUserId)
        {
            var sentMessages = _messageRepository.AllAsNoTracking()
                .Where(m => !m.IsDeleted &&
                            (m.SenderId == currentUserId || m.ReceiverId == currentUserId))
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => m.Sender);

            var receivedMessages = _messageRepository.AllAsNoTracking()
                .Where(m => !m.IsDeleted &&
                            (m.SenderId == currentUserId || m.ReceiverId == currentUserId))
                .OrderByDescending(m => m.CreatedOn)
                .Select(m => m.Receiver);

            var concatenatedMessages = await sentMessages
                .Concat(receivedMessages)
                .Where(u => u.Id != currentUserId)
                .Distinct()
                .To<T>()
                .ToListAsync();

            return concatenatedMessages;
        }
    }
}
