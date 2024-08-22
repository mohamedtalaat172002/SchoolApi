namespace School.Core.Feature.Students.Commands.Model
{
    public interface IStudentCommand
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DID { get; set; }

    }
}
