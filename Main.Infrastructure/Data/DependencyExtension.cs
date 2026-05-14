
using Data;

using IRepository;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Repository;

namespace Main.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices ( this IServiceCollection services,IConfiguration configuration )
    {
        // 1. Connection String Setup
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext> ( options =>
            options.UseSqlServer ( connectionString,b => b.MigrationsAssembly ( typeof ( AppDbContext ).Assembly.FullName ) ) );

        services.AddDbContext <ApplicationIdentityDbContext> ( options =>
            options.UseSqlServer ( connectionString,b => b.MigrationsAssembly ( typeof ( ApplicationIdentityDbContext ).Assembly.FullName ) ) );

        // 2. Identity Options Setup
        services.AddIdentityCore<IdentityUser> ( options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireUppercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredLength = 8;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes ( 5 );
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.User.RequireUniqueEmail = true;
        } )
        .AddEntityFrameworkStores<ApplicationIdentityDbContext> ( );

    services.AddScoped<IAdminPostImageRepository,AdminPostImageRepository> ( );
    services.AddScoped<IAdminPostRepository,AdminPostRepository> ( );
    services.AddScoped<IProductImageRepository,ProductImageRepository> ( );
        services.AddScoped<IProductRepository,ProductRepository> ( );
        services.AddScoped<IPageRepository,PageRepository> ( );

        return services;
    }
}

