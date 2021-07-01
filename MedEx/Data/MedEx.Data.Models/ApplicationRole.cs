using System;
using System.Collections.Generic;
using System.Text;
using MedEx.Data.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace MedEx.Data.Models
{
    public sealed class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid
                .NewGuid()
                .ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
