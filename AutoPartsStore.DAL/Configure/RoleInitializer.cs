using AutoPartsStore.AN.Entities;
using Microsoft.AspNetCore.Identity;

namespace AutoPartsStore.DAL.Configure {
    public class RoleInitializer {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager) {
            string adminEmail = "admin@gmail.com";
            string password = "!Qa2ws";
            if (await roleManager.FindByNameAsync("admin") == null) {
                await roleManager.CreateAsync(new Role { Name = "admin"});
            }
            if (await roleManager.FindByNameAsync("employee") == null) {
                await roleManager.CreateAsync(new Role { Name = "employee"});
            }
            if (await roleManager.FindByNameAsync("user") == null) {
                await roleManager.CreateAsync(new Role { Name = "user" });
            }
            if (await userManager.FindByNameAsync(adminEmail) == null) {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
