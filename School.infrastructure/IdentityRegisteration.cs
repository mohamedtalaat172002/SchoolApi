using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using School.Data.Helper;
using School.Data.Models.Identity;
using School.infrastructure.Context;
using System.Text;

namespace School.infrastructure
{
    public static class IdentityRegisteration
    {


        public static IServiceCollection AddIdentityRegisteration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole<int>>(option =>
            {
                // Password settings.
                option.Password.RequireDigit =
                option.Password.RequireLowercase =
                option.Password.RequireNonAlphanumeric =
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 8;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = false;

            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            //JWT Authentication
            var jwtSetting = new JwtSettings();

            configuration.GetSection("jwtSettings").Bind(jwtSetting);

            services.AddSingleton(jwtSetting);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = jwtSetting.validateIssuer,
                   ValidIssuers = new[] { jwtSetting.issuer },
                   ValidateIssuerSigningKey = jwtSetting.validateIssuerSigningKey,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSetting.secret)),
                   ValidAudience = jwtSetting.audience,
                   ValidateAudience = jwtSetting.validateAudience,
                   ValidateLifetime = jwtSetting.validateLifetime,
               };
           });



            return services;
        }
    }
}
