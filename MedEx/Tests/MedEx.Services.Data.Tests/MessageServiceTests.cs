using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Data.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MedEx.Services.Data.Tests
{
    public class MessageServiceTests : BaseServiceTests
    {
        private Random Random => new Random();

        private IMessageService Service => ServiceProvider.GetRequiredService<IMessageService>();

        /*
        Task<IEnumerable<T>> GetAllWithUserAsync<T>(string currentUserId, string userId);

        Task<IEnumerable<T>> GetAllAsync<T>(string currentUserId);
         */


        [Fact]
        public async Task GetLastMessageAsyncShouldWorkCorrectly()
        {
            var message = await CreateMessageAsync();

            var currentUser = message.ReceiverId;
            var senderUser = message.SenderId;
            var content = message.Content;

            var result = await Service.GetLastMessageAsync(currentUser, senderUser);

            Assert.Equal(content, result);
        }

        [Fact]
        public async Task GetLastActivityAsyncShouldWorkCorrectly()
        {
            var message = await CreateMessageAsync();

            var currentUser = message.ReceiverId;
            var senderUser = message.SenderId;
            var lastMessageTime =
                message.CreatedOn.AddHours(3).ToString(GlobalConstants.DateTimeFormats.DateTimeFormat);

            var result = await Service.GetLastActivityAsync(currentUser, senderUser);

            Assert.Equal(lastMessageTime, result);
        }

        [Fact]
        public async Task CreateAsyncShouldCreateCorrectly()
        {
            await CreateMessageAsync();

            await Service.CreateAsync("test", "teststring", "teststring2");

            var result = await DbContext.Messages.CountAsync();

            Assert.Equal(2, result);
        }

        private async Task<Message> CreateMessageAsync()
        {
            var message = new Message()
            {
                SenderId = Guid.NewGuid().ToString(),
                ReceiverId = Guid.NewGuid().ToString(),
                Content = "test message"
            };

            await DbContext.Messages.AddAsync(message);
            await DbContext.SaveChangesAsync();
            return message;
        }
    }
}
