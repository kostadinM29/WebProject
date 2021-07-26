using AutoMapper;
using MedEx.Common;
using MedEx.Common.Attributes;
using MedEx.Data.Models;
using MedEx.Services.Mapping;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MedEx.Web.ViewModels.Administration.DoctorViewModels
{
    public class DoctorEditFormModel : IMapFrom<Doctor>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "New Image")]
        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = GlobalConstants.ErrorMessages.Image)]
        public IFormFile Image { get; set; }

        [Range(18, 99)]
        public int Age { get; set; }

        [MinLength(6)]
        public string PhoneNumber { get; set; } // potentially stationary/telephone

        [Display(Name = "Experience (in years)")]
        public int? Experience { get; set; } // years

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        public string Address { get; set; }

        public string Biography { get; set; }

        [Display(Name = "Town")]
        public int TownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TownItems { get; set; }

        [Display(Name = "Specialization")]
        public int SpecializationId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> SpecializationItems { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Doctor, DoctorEditFormModel>()
                .ForMember(vm => vm.ImageUrl, opt =>
                    opt.MapFrom(d =>
                        d.Images.FirstOrDefault().RemoteImageUrl != null
                            ? d.Images.FirstOrDefault().RemoteImageUrl
                            : "/img/doctors/" + d.Images.FirstOrDefault().Id + "." +
                              d.Images.FirstOrDefault().Extension));
        }
    }
}
