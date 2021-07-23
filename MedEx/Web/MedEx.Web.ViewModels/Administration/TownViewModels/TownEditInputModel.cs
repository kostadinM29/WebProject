using System.ComponentModel.DataAnnotations;
using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.Administration.TownViewModels
{
    public class TownEditInputModel :IMapFrom<Town>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)] // Lom only?
        public string Name { get; set; }

        public int? ZipCode { get; set; }

    }
}
