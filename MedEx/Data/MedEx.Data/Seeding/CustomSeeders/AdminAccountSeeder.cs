using MedEx.Common;
using MedEx.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Data.Seeding.CustomSeeders
{
    public class AdminAccountSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (!dbContext.Roles.Any())
            {
                return;
            }

            if (dbContext.Users.Any(u => u.Email == GlobalConstants.AccountsSeeding.AdminEmail))
            {
                return;
            }


            var user = new ApplicationUser()
            {
                Id = GlobalConstants.AccountsSeeding.AdminGuid,
                AccessFailedCount = 0,
                Email = GlobalConstants.AccountsSeeding.AdminEmail,
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                IsDeleted = false,
                CreatedOn = DateTime.UtcNow,
                LockoutEnabled = false,
                PhoneNumberConfirmed = true,
                PasswordHash = GlobalConstants.AccountsSeeding.AdminPasswordHash,
                UserName = GlobalConstants.AccountsSeeding.AdminUserName,
                NormalizedEmail = GlobalConstants.AccountsSeeding.AdminEmail.ToUpper(),
                NormalizedUserName = GlobalConstants.AccountsSeeding.AdminUserName.ToUpper()
            };

            user.Roles.Add(new IdentityUserRole<string>()
            {
                RoleId = dbContext.Roles
                    .FirstOrDefault(r => r.Name == GlobalConstants.AdministratorRoleName)?.Id
            });

            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
