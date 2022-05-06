/*using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebAPI.Entities.Identity;

namespace WebAPI.Context
{
    public class ApplicationContextSeed
    {
        public static async Task SeedEssential(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new Role(RoleConstant.Administrator.ToString()));
            await roleManager.CreateAsync(new Role(RoleConstant.Moderator.ToString()));
            await roleManager.CreateAsync(new Role(RoleConstant.User.ToString()));
            
            //Seed Default User
            var defaultUser = new User
            {
                Id = 1,
                FirstName = UserConstant.FirstName,
                LastName = UserConstant.LastName,
                PhoneNumber = UserConstant.default_PhoneNumber,
                Email = UserConstant.default_email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            if (userManager.Users.All(x => x.Email != defaultUser.Email))
            {
                await userManager.CreateAsync(defaultUser);
                await userManager.AddToRoleAsync(defaultUser, UserConstant.default_role.ToString());
            }
        }
    }
}*/