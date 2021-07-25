using AutoMapper;
using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.MessageViewModels
{
    public class ChatMessagesWithUserViewModel : IMapFrom<Message>, IHaveCustomMappings
    {
        public string Content { get; set; }

        public string SenderId { get; set; }

        public string SenderUserName { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Message, ChatMessagesWithUserViewModel>()
                .ForMember(vm => vm.CreatedOn, opt =>
                    opt.MapFrom(m => m.CreatedOn.AddHours(3).ToString(GlobalConstants.DateTimeFormats.DateTimeFormat)));
        }
    }
}
