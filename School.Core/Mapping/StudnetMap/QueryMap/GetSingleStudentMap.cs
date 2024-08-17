using School.Core.Feature.Students.Queries.Result;
using School.Data.Models;

namespace School.Core.Mapping.StudnetMap
{
    public partial class StudentProfile
    {
        void GetSingleStudentMap()
        {
            CreateMap<Student, GetSingleStudentDto>()
             .ForMember(s => s.Name, sr => sr.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
             .ForMember(d => d.DeptName, sr => sr.MapFrom(s => s.Localize(s.Department.DNameAr, s.Department.DNameEn)));
        }
    }
}
