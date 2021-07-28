using AutoMapper;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System.Globalization;
using MedEx.Common;

namespace MedEx.Web.ViewModels.RatingViewModels
{
    public class RatingViewModel : IMapFrom<Rating>, IHaveCustomMappings
    {
        public string PatientFullName { get; set; }

        public int Number { get; set; }

        public string Comment { get; set; }

        public string CreatedOn { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Rating, RatingViewModel>()
                .ForMember(vm => vm.PatientFullName, opt =>
                    opt.MapFrom(r => r.Patient.FirstName + " " + r.Patient.LastName))
                .ForMember(vm => vm.CreatedOn, opt =>
                    opt.MapFrom(r => r.CreatedOn.ToString(GlobalConstants.DateTimeFormats.DateTimeFormat)));
        }
    }
}
