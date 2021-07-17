using MedEx.Data.Common.Models;

namespace MedEx.Data.Models
{
    public class Town : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int? ZipCode { get; set; }
    }
}
