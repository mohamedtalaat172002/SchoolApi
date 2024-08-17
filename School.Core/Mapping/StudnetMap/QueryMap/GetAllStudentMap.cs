using School.Core.Feature.Students.Queries.Result;
using School.Data.Models;

namespace School.Core.Mapping.StudnetMap
{
    public partial class StudentProfile
    {
        void GetAllStudentMap()
        {
            CreateMap<Student, GetAllStudentsDto>()
                .ForMember(s => s.Name, sr => sr.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                .ForMember(d => d.DeptName, s => s.MapFrom(sr => sr.Localize(sr.Department.DNameAr, sr.Department.DNameEn)));
        }
    }
}
