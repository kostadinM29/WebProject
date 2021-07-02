using MedEx.Data.Common.Models;

namespace MedEx.Data.Models
{
    public class Picture : BaseDeletableModel<int>
    {
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
