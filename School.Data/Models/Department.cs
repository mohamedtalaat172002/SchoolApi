using School.Data.Common;
using System.ComponentModel.DataAnnotations;

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
        public int DID { get; set; }
        [StringLength(200)]
        public string DNameEn { get; set; }
        [StringLength(200)]
        public string DNameAr { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmetSubject> DepartmentSubjects { get; set; }
    }
}
