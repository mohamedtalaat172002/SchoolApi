using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Feature.Users.Command.Model;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> RegisterUser([FromBody] AddUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);
            return NewResult(response);
        }
    }
}
