using System.Collections.Generic;
using MedEx.Data.Common.Models;

namespace MedEx.Data.Models
{
    public class Specialization : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
