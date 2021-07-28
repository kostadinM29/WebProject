using System.ComponentModel.DataAnnotations;

namespace MedEx.Web.ViewModels.HomeViewModels
{
    public class FeedbackCreateFormModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Select a type.")]
        public string Type { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Comment { get; set; }
    }
}
