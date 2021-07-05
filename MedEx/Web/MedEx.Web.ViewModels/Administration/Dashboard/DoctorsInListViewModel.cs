using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.Administration.Dashboard
{
    public class DoctorsInListViewModel : IMapFrom<Doctor>
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PictureImagePath { get; set; }

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
    }
}
