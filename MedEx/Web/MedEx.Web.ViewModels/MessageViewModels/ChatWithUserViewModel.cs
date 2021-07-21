using System.Collections.Generic;

namespace MedEx.Web.ViewModels.MessageViewModels
{
    public class ChatWithUserViewModel
    {
        public ChatUserViewModel User { get; set; }

        public IEnumerable<ChatMessagesWithUserViewModel> Messages { get; set; }
    }
}
