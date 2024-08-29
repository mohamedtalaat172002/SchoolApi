using Microsoft.Extensions.DependencyInjection;
using School.infrastructure.Abstract;
using School.infrastructure.Implementaion;

namespace School.infrastructure
{
    public static class InfrastrucureDependecies
    {
        public static IServiceCollection AddInfrastrucureDependencies(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient<IStudentInfrastructure, StudentInfrastructure>();
            services.AddTransient<IDepartmentInfrastructure, DepartmentInfrastructure>();
            return services;
        }
    }
}
