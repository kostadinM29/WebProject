using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.MessageViewModels
{
    public class ChatConversationsViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string LastMessage { get; set; }

        public string LastMessageActivity { get; set; }

    }
}
