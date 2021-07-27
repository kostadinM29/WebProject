using MedEx.Common;
using MedEx.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Data.Seeding.CustomSeeders
{
    public class DoctorsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Doctors.Any())
            {
                return;
            }

            var doctorUser = await dbContext.ApplicationUsers
                .Where(u => u.Email == GlobalConstants.AccountsSeeding.DoctorEmail).FirstOrDefaultAsync();

            var doctor = new Doctor()
            {
                FirstName = "Daniela",
                LastName = "Spasova",
                Age = 24,
                PhoneNumber = "0885254553",
                Experience = 10,
                Email = "dspasova@gmail.com",
                Address = "bul. Peshtersko Shose 123",
                Biography =
                    "Since 2014 Dr. Spasova has been working at DCC Plovdiv, and since 2015 he has an office at MC 1 Plovdiv. She speaks English.",
                TownId = 2,
                SpecializationId = 1,
                User = doctorUser,
                HasApplied = true,
                IsValidated = true
            };

            var image = new Image()
            {
                Doctor = doctor,
                RemoteImageUrl = "https://med-advisor.site/files/products/gulsumaydin.600x340.jpg.pagespeed.ce.ndnt82GhOH.jpg"
            };

            doctor.Images.Add(image);

            doctorUser.Doctor = doctor;

            await dbContext.Doctors.AddAsync(doctor);
            await dbContext.SaveChangesAsync();
        }
    }
}
