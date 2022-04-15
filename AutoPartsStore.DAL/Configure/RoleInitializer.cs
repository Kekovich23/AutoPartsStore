using AutoPartsStore.AN.Entities;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.DAL.Configure {
    public class RoleInitializer {
        public const string AdminRoleName = "admin";
        public const string EmployeeRoleName = "employee";
        public const string UserRoleName = "user";

        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager) {
            await CreateRole(roleManager, AdminRoleName);
            await CreateRole(roleManager, EmployeeRoleName);
            await CreateRole(roleManager, UserRoleName);

            await CreateUser(userManager, "admin@gmail.com", "!Qa2ws", AdminRoleName);
        }

        private static async Task CreateUser(UserManager<User> userManager, string email, string password, string roleName) {
            if (await userManager.FindByNameAsync(email) == null) {
                User user = new() { Email = email, UserName = email };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, roleName);
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
