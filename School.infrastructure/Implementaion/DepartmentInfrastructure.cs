using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.infrastructure.Abstract;
using School.infrastructure.Context;

namespace School.infrastructure.Implementaion
{
    public class DepartmentInfrastructure : GenericRepositoryAsync<Department>,
                                            IDepartmentInfrastructure
    {
        private readonly DbSet<Department> _dbSet;
        public DepartmentInfrastructure(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Department>();
        }

    }
}
