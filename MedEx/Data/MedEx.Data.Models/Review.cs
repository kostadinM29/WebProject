using MedEx.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Review : BaseDeletableModel<int>
    {
        [Required]
        public int Rating { get; set; } // 0-10

        [ForeignKey(nameof(Comment))]
        public int? CommentId { get; set; }

        public Comment Comment { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int? DoctorId { get; set; }

        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
