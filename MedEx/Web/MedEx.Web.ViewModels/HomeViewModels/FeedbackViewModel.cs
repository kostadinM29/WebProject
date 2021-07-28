using AutoMapper;
using MedEx.Common;
using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.HomeViewModels
{
    public class FeedbackViewModel : IMapFrom<Feedback>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string CreatedOn { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }

        public string Comment { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(vm => vm.FullName, opt =>
                    opt.MapFrom(d => d.FirstName + " " + d.LastName))
                .ForMember(vm => vm.CreatedOn, opt =>
                    opt.MapFrom(r => r.CreatedOn.ToString(GlobalConstants.DateTimeFormats.DateTimeFormat)));
        }
    }
}
