// IDatabaseSeeder.cs & DatabaseSeeder.cs
using Microsoft.AspNetCore.Identity;

namespace Data;

public interface IDatabaseSeeder
{
    Task SeedAsync ( );
}

public class DatabaseSeeder (
    ApplicationIdentityDbContext identityDbContext,
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager ): IDatabaseSeeder
{
    public async Task SeedAsync ( )
    {
        string[] roles = ["Admin", "User","Company"];
        foreach ( var role in roles )
        {
            if ( !await roleManager.RoleExistsAsync ( role ) )
            {
                await roleManager.CreateAsync ( new IdentityRole ( role ) );
            }
        }

        // 3. Admin User Seeding
        var adminEmail = "admin@company.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if ( adminUser == null )
        {
            adminUser = new IdentityUser { UserName = adminEmail,Email = adminEmail,EmailConfirmed = true };
            var result = await userManager.CreateAsync(adminUser, "SecureP@ss123!");
            if ( result.Succeeded )
            {
                await userManager.AddToRoleAsync ( adminUser,"Admin" );
            }
        }


        // 3. Company User Seeding
        var companyEmail = "finearts@company.com";
        var companyUser = await userManager.FindByEmailAsync(companyEmail);
        if ( companyUser == null )
        {
            companyUser = new IdentityUser { 
                UserName = companyEmail,Email = companyEmail,EmailConfirmed = true };
            var result = await userManager.CreateAsync(companyUser, "SecureP@ss123!");
            if ( result.Succeeded )
            {
                await userManager.AddToRoleAsync ( companyUser,"Company" );
            }
        }
    }
}

