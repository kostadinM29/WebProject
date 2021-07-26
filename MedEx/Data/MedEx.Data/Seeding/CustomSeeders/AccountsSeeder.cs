using MedEx.Common;
using MedEx.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedEx.Data.Seeding.CustomSeeders
{
    public class AccountsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

            // Create Admin
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.AdminEmail,
                GlobalConstants.AdministratorRoleName);

            // Create Doctor
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.DoctorEmail,
                GlobalConstants.DoctorRoleName);

            // Create Patient
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.PatientEmail,
                GlobalConstants.PatientRoleName);

            // Create User
            await CreateUser(
                userManager,
                roleManager,
                GlobalConstants.AccountsSeeding.UserEmail);
        }

        private static async Task CreateUser(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, string email, string roleName = null)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            const string password = GlobalConstants.AccountsSeeding.Password;

            if (roleName != null)
            {
                var role = await roleManager.FindByNameAsync(roleName);

                if (!userManager.Users.Any(u => u.Roles.Any(r => r.RoleId == role.Id)))
                {
                    var result = await userManager.CreateAsync(user, password);

                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, roleName);
                    }
                }
            }
            else
            {
                await userManager.CreateAsync(user, password);
            }
        }
    }
}
