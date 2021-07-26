using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.Administration.SpecializationViewModels
{
    public class SpecializationEditFormModel : IMapFrom<Specialization>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Description { get; set; }
    }
}
