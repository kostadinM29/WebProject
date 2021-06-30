using MedEx.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedEx.Data
{
    public class MedExDbContext : IdentityDbContext
    {
       public DbSet<Appointment> Appointments { get; set; }

       public DbSet<ApplicationUser>  { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

       public DbSet<Picture> Pictures { get; set; }

       public DbSet<Review> Reviews { get; set; }

       public DbSet<Town> Towns { get; set; }


        public MedExDbContext(DbContextOptions<MedExDbContext> options)
            : base(options)
        {
        }
    }
}
