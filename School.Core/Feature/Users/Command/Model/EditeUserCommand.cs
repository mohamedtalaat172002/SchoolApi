using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Users.Command.Model
{
    public class EditeUserCommand : IUserCommand,
                 IRequest<Response<String>>

    {
        public int Id { get; set; }

    }
}
