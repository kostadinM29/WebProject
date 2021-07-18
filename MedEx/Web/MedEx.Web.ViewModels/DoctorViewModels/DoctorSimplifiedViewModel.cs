using AutoMapper;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System.Linq;

namespace MedEx.Web.ViewModels.DoctorViewModels
{
    public class DoctorSimplifiedViewModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Doctor, DoctorSimplifiedViewModel>()
                .ForMember(vm => vm.ImageUrl, opt =>
                    opt.MapFrom(d =>
                        d.Images.FirstOrDefault().RemoteImageUrl != null
                            ? d.Images.FirstOrDefault().RemoteImageUrl
                            : "/img/doctors/" + d.Images.FirstOrDefault().Id + "." +
                              d.Images.FirstOrDefault().Extension))
                .ForMember(vm => vm.FullName, opt =>
                    opt.MapFrom(d => d.FirstName + " " + d.LastName));
        }
    }
}
