using MedEx.Data.Common.Models;
using System.Collections.Generic;

namespace MedEx.Data.Models
{
    public class Specialization : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
