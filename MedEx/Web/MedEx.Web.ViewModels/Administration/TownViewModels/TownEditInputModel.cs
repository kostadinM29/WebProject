using MedEx.Data.Models;
using MedEx.Services.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.Administration.TownViewModels
{
    public class TownEditInputModel : IMapFrom<Town>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)] // Lom only?
        public string Name { get; set; }

        public int? ZipCode { get; set; }
    }
}
