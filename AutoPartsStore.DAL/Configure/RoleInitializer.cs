using AutoPartsStore.AN.Entities;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.DAL.Configure {
    public class RoleInitializer {
        public const string AdminRoleName = "admin";
        // TODO: other roles

        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager) {
            string adminEmail = "admin@gmail.com";
            string password = "!Qa2ws";

            await CreateRole(roleManager, AdminRoleName);
            // TODO: other roles
            if (await roleManager.FindByNameAsync("employee") == null) {
                await roleManager.CreateAsync(new Role { Name = "employee"});
            }
            if (await roleManager.FindByNameAsync("user") == null) {
                await roleManager.CreateAsync(new Role { Name = "user" });
            }

            // TODO: the same for users
            if (await userManager.FindByNameAsync(adminEmail) == null) {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(admin, AdminRoleName);
                }
            }
        }

        private static async Task CreateRole(RoleManager<Role> roleManager, string roleName) {
            if (await roleManager.FindByNameAsync(roleName) == null) {
                await roleManager.CreateAsync(new Role { Name = roleName });
            }
        }
    }
}
