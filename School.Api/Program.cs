
using Microsoft.EntityFrameworkCore;
using School.Core;
using School.Core.Middleware;
using School.infrastructure;
using School.infrastructure.Context;
using School.Service;
namespace School.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer
            (builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCoreDependencies()
                            .AddInfrastrucureDependencies()
                            .AddServiceDependencies();



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

            app.Run();
        }
    }
}



