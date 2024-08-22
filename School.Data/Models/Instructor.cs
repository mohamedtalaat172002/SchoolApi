using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class Instructor
    {
        public Instructor()
        {
            instructors = new HashSet<Instructor>();
            Ins_Subjects = new HashSet<InstructorSubject>();
        }
        [Key]
        public int InsId { get; set; }
        public string? ENameAr { get; set; }
        public string? ENameEn { get; set; }
        public string? Address { get; set; }
        public string? Position { get; set; }
        public int? SupervisorId { get; set; }
        public decimal? Salary { get; set; }
        public int DID { get; set; }
        //1 <==> M
        [ForeignKey(nameof(DID))]
        [InverseProperty(nameof(Department.Instructors))]
        public Department? department { get; set; }

        [InverseProperty(nameof(Department.InstructorMgr))]
        public Department? deptManger { get; set; }

        [ForeignKey(nameof(SupervisorId))]
        [InverseProperty("instructors")]
        public Instructor? SuperVisorInstructor { get; set; }

        [InverseProperty("SuperVisorInstructor")]
        public virtual ICollection<Instructor> instructors { get; set; }
        [InverseProperty(nameof(InstructorSubject.Instructor))]
        public virtual ICollection<InstructorSubject> Ins_Subjects { get; set; }


    }
}
