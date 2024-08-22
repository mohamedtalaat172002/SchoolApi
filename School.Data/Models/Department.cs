using School.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class Department : LocalizeEntity
    {
        public Department()
        {
            Students = new HashSet<Student>();
            DepartmentSubjects = new HashSet<DepartmetSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int DID { get; set; }
        [StringLength(200)]
        public string? DNameEn { get; set; }
        [StringLength(200)]
        public string? DNameAr { get; set; }
        public int InsManagerId { get; set; }


        [InverseProperty(nameof(Student.Department))]
        public virtual ICollection<Student> Students { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }

        [InverseProperty(nameof(Instructor.department))]
        public virtual ICollection<Instructor> Instructors { get; set; }

        [ForeignKey(nameof(InsManagerId))]
        [InverseProperty(nameof(Instructor.deptManger))]
        public virtual Instructor? InstructorMgr { get; set; }

    }
}
