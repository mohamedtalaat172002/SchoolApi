using School.Core.Feature.Students.Queries.Result;
using School.Data.Models;

namespace School.Core.Mapping.StudnetMap
{
    public partial class StudentProfile
    {
        void GetAllStudentMap()
        {
            CreateMap<Student, GetAllStudentsDto>()
                .ForMember(d => d.DeptName, s => s.MapFrom(sr => sr.Department.DName));
        }
    }
}
