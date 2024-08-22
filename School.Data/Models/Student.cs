using School.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class Student : LocalizeEntity
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int StudID { get; set; }
        [StringLength(200)]

        public string? NameAr { get; set; }
        [StringLength(200)]
        public string? NameEn { get; set; }
        [StringLength(500)]
        public string? Address { get; set; }
        [StringLength(500)]
        public string? Phone { get; set; }
        public int? DID { get; set; }

        [ForeignKey("DID")]
        [InverseProperty(nameof(Department.Students))]
        public virtual Department Department { get; set; }
        [InverseProperty("student")]
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
