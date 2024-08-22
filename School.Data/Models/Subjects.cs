using School.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class Subjects : LocalizeEntity
    {
        public Subjects()
        {
            StudentsSubjects = new HashSet<StudentSubject>();
            DepartmetsSubjects = new HashSet<DepartmetSubject>();
            InstructorsSubjects = new HashSet<InstructorSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        [StringLength(500)]
        public string? SubjectNameEn { get; set; }
        [StringLength(500)]
        public string? SubjectNameAr { get; set; }
        public DateTime? Period { get; set; }

        [InverseProperty("Subject")]
        public virtual ICollection<StudentSubject> StudentsSubjects { get; set; }
        [InverseProperty("Subjects")]

        public virtual ICollection<DepartmetSubject> DepartmetsSubjects { get; set; }
        [InverseProperty("Subjects")]
        public virtual ICollection<InstructorSubject> InstructorsSubjects { get; set; }

    }
}
