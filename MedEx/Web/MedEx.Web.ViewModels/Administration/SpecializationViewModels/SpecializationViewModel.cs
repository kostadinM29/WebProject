using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.Administration.SpecializationViewModels
{
    public class SpecializationViewModel : IMapFrom<Specialization>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
