using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.Administration.TownViewModels
{
    public class TownCreateFormModel
    {
        [Required]
        [StringLength(30, MinimumLength = 3)] // Lom only?
        public string Name { get; set; }

        public int? ZipCode { get; set; }
    }
}
