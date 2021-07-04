using MedEx.Data.Common.Models;

namespace MedEx.Data.Models
{
    public class Picture : BaseDeletableModel<int>
    {
        public string ImagePath { get; set; }
    }
}
