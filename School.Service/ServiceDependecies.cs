using Microsoft.Extensions.DependencyInjection;
using School.Service.Abstract;
using School.Service.Implementaion;

namespace School.Service
{
    public static class ServiceDependecies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            return services;
        }

    }
}
