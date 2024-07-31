using School.Core.Feature.Students.Queries.Result;
using School.Data.Models;

namespace School.Core.Mapping.StudnetMap
{
    public partial class StudentProfile
    {
        void GetSingleStudentMap()
        {
            CreateMap<Student, GetSingleStudentDto>()
             .ForMember(d => d.DeptName, sr => sr.MapFrom(s => s.Department.DName));
        }
    }
}
