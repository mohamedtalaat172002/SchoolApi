
using MediatR;
using School.Core.Base;


namespace School.Core.Feature.Users.Command.Model
{
    public class DeleteUserCommand : IRequest<Response<String>>
    {
        public int id { get; set; }
        public DeleteUserCommand(int id)
        {
            this.id = id;
        }
    }
}
