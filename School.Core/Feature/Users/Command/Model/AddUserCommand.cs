using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Users.Command.Model
{
    public class AddUserCommand : IUserCommand,
        IRequest<Response<String>>
    {

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
