using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Data.Models
{
    public class StudentSubject
    {


        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }
        public decimal? Grad { get; set; }
        [ForeignKey("StudID")]
        [InverseProperty("StudentSubjects")]
        public virtual Student? student { get; set; }

        [ForeignKey("SubID")]
        [InverseProperty("StudentsSubjects")]
        public virtual Subjects? Subject { get; set; }

    }
}
