using Microsoft.EntityFrameworkCore;
using School.Data.Models;

namespace School.infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<Subjects> Subjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DepartmetSubject>().
                HasKey(t => new { t.SubID, t.DID });

            modelBuilder.Entity<InstructorSubject>()
                .HasKey(t => new { t.InsId, t.SubId });

            modelBuilder.Entity<StudentSubject>()
                .HasKey(t => new { t.SubID, t.StudID });


            modelBuilder.Entity<Instructor>()
                .HasOne(x => x.SuperVisorInstructor)
                .WithMany(c => c.instructors)
                .HasForeignKey(d => d.SupervisorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Department>()
                .HasOne(x => x.InstructorMgr)
                .WithOne(x => x.deptManger)
                .HasForeignKey<Department>(d => d.InsManagerId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);
        }
    }
}
