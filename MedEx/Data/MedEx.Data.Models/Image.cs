using MedEx.Data.Common.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            Id = Guid.NewGuid().ToString();
        }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }
    }
}
