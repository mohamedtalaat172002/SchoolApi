using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Students.Commands.Model
{
    public class EditeStudentCommand : IStudentCommand,
        IRequest<Response<String>>
    {
        public int StudID { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? DID { get; set; }

    }
}
