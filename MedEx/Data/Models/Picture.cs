﻿using System;

namespace MedEx.Data.Models
{
    public class Picture
    {
        public string Id { get; set; } = new Guid().ToString();

        public string Description { get; set; }

        public string  ImagePath { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
