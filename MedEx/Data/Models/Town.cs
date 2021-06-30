using System;

namespace MedEx.Data.Models
{
    public class Town
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int ZipCode { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }

}

