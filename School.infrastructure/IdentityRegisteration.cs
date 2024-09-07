using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using School.Data.Models.Identity;
using School.infrastructure.Context;

namespace School.infrastructure
{
    public static class IdentityRegisteration
    {
        public static IServiceCollection AddIdentityRegisteration(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<int>>(option =>
            {
                // Password settings.
                option.Password.RequireDigit =
                option.Password.RequireLowercase =
                option.Password.RequireNonAlphanumeric =
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
