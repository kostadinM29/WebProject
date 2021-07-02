using MedEx.Data.Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class Comment : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
