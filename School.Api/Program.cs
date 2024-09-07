
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using School.Core;
using School.Core.Middleware;
using School.infrastructure;
using School.infrastructure.Context;
using School.Service;
using System.Globalization;
using System.Text.Json.Serialization;
namespace School.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCoreDependencies()
                            .AddInfrastrucureDependencies()
                            .AddServiceDependencies()
                            .AddIdentityRegisteration();

            builder.Services.AddControllersWithViews();
            //Localization Configuration
            builder.Services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });
            //builder.Services.AddControllers()
            //.AddViewLocalization()
            //.AddDataAnnotationsLocalization();

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>
                {
                     new CultureInfo("En-US"),
                     new CultureInfo("de-DE"),
                     new CultureInfo("fr-FR"),
                     new CultureInfo("Ar-EG")
               };

                options.DefaultRequestCulture = new RequestCulture("En-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.Run();
        }
    }
}



