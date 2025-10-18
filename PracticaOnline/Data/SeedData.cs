using Microsoft.AspNetCore.Identity;
using NetIdentity.Models;

namespace NetIdentity.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();


            string[] roleNames = { "Admin", "Usuario" };
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Admin
            var adminExisting = await userManager.FindByEmailAsync("admin@test.com");
            if (adminExisting == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com",
                    FechaNacimiento = DateTime.Now.AddYears(-30),
                    NombreCompleto = "Administrador Sistema",
                    EmailConfirmed = true,
                    genero = "Otro"
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    await userManager.AddClaimAsync(adminUser,
                        new System.Security.Claims.Claim("FechaNacimiento", adminUser.FechaNacimiento.ToString("yyyy-MM-dd")));
                }
            }
            else if (string.IsNullOrWhiteSpace(adminExisting.genero))
            {
                adminExisting.genero = "Otro";
                await userManager.UpdateAsync(adminExisting);
            }

            // Usuario menor
            var userMenorExisting = await userManager.FindByEmailAsync("menor@test.com");
            if (userMenorExisting == null)
            {
                var userMenor = new ApplicationUser
                {
                    UserName = "menor@test.com",
                    Email = "menor@test.com",
                    FechaNacimiento = DateTime.Now.AddYears(-15),
                    NombreCompleto = "Juan Menor",
                    EmailConfirmed = true,
                    genero = "Masculino"
                };

                var result = await userManager.CreateAsync(userMenor, "Menor123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userMenor, "Usuario");
                    await userManager.AddClaimAsync(userMenor,
                        new System.Security.Claims.Claim("FechaNacimiento", userMenor.FechaNacimiento.ToString("yyyy-MM-dd")));
                }
            }
            else if (string.IsNullOrWhiteSpace(userMenorExisting.genero))
            {
                userMenorExisting.genero = "Masculino";
                await userManager.UpdateAsync(userMenorExisting);
            }

            // Usuario mayor
            var userMayorExisting = await userManager.FindByEmailAsync("mayor@test.com");
            if (userMayorExisting == null)
            {
                var userMayor = new ApplicationUser
                {
                    UserName = "mayor@test.com",
                    Email = "mayor@test.com",
                    FechaNacimiento = DateTime.Now.AddYears(-25),
                    NombreCompleto = "María Mayor",
                    EmailConfirmed = true,
                    genero = "Femenino"
                };

                var result = await userManager.CreateAsync(userMayor, "Mayor123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userMayor, "Usuario");
                    await userManager.AddClaimAsync(userMayor,
                        new System.Security.Claims.Claim("FechaNacimiento", userMayor.FechaNacimiento.ToString("yyyy-MM-dd")));
                }
            }
            else if (string.IsNullOrWhiteSpace(userMayorExisting.genero))
            {
                userMayorExisting.genero = "Femenino";
                await userManager.UpdateAsync(userMayorExisting);
            }
        }
    }


}
