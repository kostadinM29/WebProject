using AutoMapper;
using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.MessageViewModels
{
    public class ChatUserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, ChatUserViewModel>()
                .ForMember(vm => vm.FullName, opt =>
                    opt.MapFrom(u => u.Doctor.FirstName != null
                        ? "Dr. " + u.Doctor.FirstName + " " + u.Doctor.LastName
                        : u.Patient.FirstName + " " + u.Patient.LastName));
        }
    }
}
