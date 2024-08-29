using School.Core.Feature.Dpartments.Query.Result;
using School.Data.Models;

namespace School.Core.Mapping.DepartmentMap
{
    public partial class DepartementProfile
    {
        public void GetDeptByIdMap()
        {


            CreateMap<Department, GetSigleDeptbyIdDto>()
            .ForMember(d => d.DepartmentName, sr => sr.MapFrom(s => s.Localize(s.DNameAr, s.DNameEn)))
            .ForMember(d => d.ManagerName, sr => sr.MapFrom(s => s.InstructorMgr != null ? s.InstructorMgr.Localize(s.InstructorMgr.InsNameAr, s.InstructorMgr.InsNameEn) : null))
            .ForMember(dest => dest.SubjectsList, opt => opt.MapFrom(src => src.DepartmentSubjects.Select(ds => ds.Subjects)))
            .ForMember(dest => dest.InstructorsList, opt => opt.MapFrom(src => src.Instructors));

            CreateMap<Subjects, SubjectResponse>()
                .ForMember(sr => sr.id, s => s.MapFrom(s => s.SubID))
                .ForMember(d => d.name, s => s.MapFrom(s => s.Localize(s.SubjectNameAr, s.SubjectNameEn)));

            CreateMap<Instructor, InstructorResponse>()
                .ForMember(d => d.id, s => s.MapFrom(sr => sr.InsId))
                .ForMember(d => d.name, s => s.MapFrom(sr => sr.Localize(sr.InsNameAr, sr.InsNameEn)));



        }
    }
}
