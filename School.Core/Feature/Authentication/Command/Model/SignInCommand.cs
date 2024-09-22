using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Authentication.Command.Model
{
    public class SignInCommand : IRequest<Response<String>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public SignInCommand(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

    }
}
