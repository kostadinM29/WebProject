using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Data.Models.BaseModels
{
    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
