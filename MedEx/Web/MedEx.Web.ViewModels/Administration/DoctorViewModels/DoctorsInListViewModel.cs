using AutoMapper;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System.Collections.Generic;
using System.Linq;

namespace MedEx.Web.ViewModels.Administration.DoctorViewModels
{
    public class DoctorsInListViewModel : IMapFrom<Doctor>, IHaveCustomMappings // because of folder name
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public IEnumerable<Image> Images { get; set; } // TODO fix

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public int? Experience { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Biography { get; set; }

        public string TownName { get; set; }

        public string SpecializationName { get; set; }

        public bool HasApplied { get; set; }

        public bool IsValidated { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Doctor, DoctorsInListViewModel>() // TODO fix
                .ForMember(x => x.Images, opt =>
                    opt.MapFrom(x =>
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                            x.Images.FirstOrDefault().RemoteImageUrl :
                            "/img/doctors/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
