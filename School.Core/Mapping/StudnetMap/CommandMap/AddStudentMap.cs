using School.Core.Feature.Students.Commands.Model;
using School.Data.Models;

namespace School.Core.Mapping.StudnetMap
{
    public partial class StudentProfile
    {
        void AddStudentMap()
        {
            CreateMap<EditeStudentCommand, Student>();
        }
    }
}
