using Common.Helpers;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Data.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new IdentityRole(RolesEnum.SuperAdmin.ToString()));
                await roleManger.CreateAsync(new IdentityRole(RolesEnum.Admin.ToString()));
                await roleManger.CreateAsync(new IdentityRole(RolesEnum.User.ToString()));
            }
        }
    }
}
