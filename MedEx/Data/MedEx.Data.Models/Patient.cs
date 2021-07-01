using System.ComponentModel.DataAnnotations.Schema;
using MedEx.Data.Common.Models;

namespace MedEx.Data.Models
{
    public class Patient : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
