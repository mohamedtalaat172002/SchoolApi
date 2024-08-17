using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Students.Commands.Model
{
    public class AddStudentCommand : IStudentCommand
        , IRequest<Response<String>>
    {

        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DID { get; set; }
    }
}
