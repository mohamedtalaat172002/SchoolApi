using Microsoft.EntityFrameworkCore;
using School.Data.Models;

namespace School.infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContext) : base(dbContext)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }

    }
}
