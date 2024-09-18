using MediatR;
using School.Core.Base;

namespace School.Core.Feature.Users.Command.Model
{
    public class ChangeUserPasswordCommand : IRequest<Response<String>>
    {
        public int Id { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
