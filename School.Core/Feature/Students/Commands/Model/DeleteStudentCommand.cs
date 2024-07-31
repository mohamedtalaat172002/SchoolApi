using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Students.Commands.Model
{
    public class DeleteStudentCommand : IRequest<Response<String>>
    {
        public int id { get; set; }
        public DeleteStudentCommand(int id = 0)
        {
            this.id = id;
        }
    }
}
