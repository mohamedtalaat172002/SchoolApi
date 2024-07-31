using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.infrastructure.Abstract;
using School.infrastructure.Context;

namespace School.infrastructure.Implementaion
{
    public class StudentInfrastructure : GenericRepositoryAsync<Student>
                                        , IStudentInfrastructure
    {

        private readonly DbSet<Student> _students;
        public StudentInfrastructure(ApplicationDbContext dbContext) : base(dbContext)
        {
            _students = dbContext.Set<Student>();
        }



    }

}
