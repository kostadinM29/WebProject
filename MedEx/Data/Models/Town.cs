using System;
using MedEx.Data.Models.BaseModels;

namespace MedEx.Data.Models
{
    public class Town : BaseModel<int>
    {
        public string Name { get; set; }

        public int ZipCode { get; set; }
    }
}

