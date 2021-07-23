using MedEx.Data.Models;
using MedEx.Services.Mapping;

namespace MedEx.Web.ViewModels.Administration.TownViewModels
{
    public class TownViewModel : IMapFrom<Town>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ZipCode { get; set; }
    }
}
