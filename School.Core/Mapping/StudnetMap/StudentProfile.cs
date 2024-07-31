using AutoMapper;

namespace School.Core.Mapping.StudnetMap
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetAllStudentMap();
            GetSingleStudentMap();
            AddStudentMap();
            EditeStudentMap();

        }
    }
}
