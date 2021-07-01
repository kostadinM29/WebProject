using MedEx.Data.Models.BaseModels;
using System.Collections.Generic;

namespace MedEx.Data.Models
{
    public class Specialization : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
