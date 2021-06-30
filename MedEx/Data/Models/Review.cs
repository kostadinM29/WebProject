using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Review
    {
        public string Id { get; set; } 

        [Required]
        public int Rating { get; set; } // 0-10

        [ForeignKey(nameof(Comment))]
        public string CommentId { get; set; }
        public Comment Comment { get; set; }

        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
