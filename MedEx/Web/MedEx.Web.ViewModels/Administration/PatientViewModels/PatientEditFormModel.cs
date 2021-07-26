using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.Administration.PatientViewModels
{
    public class PatientEditFormModel : IMapFrom<Patient>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required]
        [Range(1, 99)]
        public int Age { get; set; }

        public string Gender { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Display(Name = "Town")]
        public int TownId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TownItems { get; set; }
    }
}
