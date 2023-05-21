using Microsoft.AspNetCore.Identity;

namespace BusLiner.MVC
{
    public static class Seed
    {
        public async static void SeedRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            var userStore = serviceProvider.GetRequiredService<IUserStore<IdentityUser>>();
            var emailStore = (IUserEmailStore<IdentityUser>)userStore;

            string[] roles = { "Admin", "User", "Manager" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                    if (role == "Admin")
                    {
                        var user = new IdentityUser();
                        user.EmailConfirmed = true;
                        await userStore.SetUserNameAsync(user, "vitalijhnativ73@gmail.com", CancellationToken.None);
                        await emailStore.SetEmailAsync(user, "vitalijhnativ73@gmail.com", CancellationToken.None);
                        var result = await userManager.CreateAsync(user, "Admin2232622!");

                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, "Admin");
                        }
                    }
                }
            }
        }
    }
}
