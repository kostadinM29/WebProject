using MedEx.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Data.Seeding.CustomSeeders
{
    public class TownsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Towns.Any())
            {
                return;
            }

            var towns = new Town[]
            {
                new Town
                {
                    Name = "Sofia",
                    ZipCode = 1000
                },
                new Town
                {
                    Name = "Plovdiv",
                    ZipCode = 4000
                },
                new Town
                {
                    Name = "Varna",
                    ZipCode = 9000
                },
                new Town
                {
                    Name = "Burgas",
                    ZipCode = 8000
                },
            };

            // Need them in particular order
            foreach (var town in towns)
            {
                await dbContext.AddAsync(town);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
