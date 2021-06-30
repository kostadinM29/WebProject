using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedEx.Data
{
    public class MedExDbContext : IdentityDbContext
    {
        public MedExDbContext(DbContextOptions<MedExDbContext> options)
            : base(options)
        {
        }
    }
}
