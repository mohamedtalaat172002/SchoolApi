using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class InstructorSubject
    {
        [Key]
        public int InsId { get; set; }
        [Key]
        public int SubId { get; set; }

        [ForeignKey("InsId")]
        [InverseProperty("Ins_Subjects")]
        public Instructor? Instructor { get; set; }
        [ForeignKey("SubId")]
        [InverseProperty("InstructorsSubjects")]
        public Subjects? Subjects { get; set; }
    }
}
