using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Feature.Authentication.Command.Model;

namespace School.Api.Controllers
{
    [ApiController]
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.Authentication.SignIn)]
        public async Task<IActionResult> SignIn([FromBody] SignInCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }

    }
}
