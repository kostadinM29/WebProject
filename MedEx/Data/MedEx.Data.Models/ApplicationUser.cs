using MedEx.Data.Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedEx.Data.Models
{
    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        [ForeignKey(nameof(Patient))]
        public int? PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int? DoctorId { get; set; }

        public virtual Doctor Doctor { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; } = new List<IdentityUserRole<string>>();

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; } = new List<IdentityUserClaim<string>>();

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; } = new List<IdentityUserLogin<string>>();

        public virtual ICollection<Message> SentMessages { get; set; } = new List<Message>();

        public virtual ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
    }
}
