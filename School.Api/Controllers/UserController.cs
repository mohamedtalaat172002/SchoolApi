using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Feature.Users.Command.Model;
using School.Core.Feature.Users.Queries.Model;

namespace School.Api.Controllers
{

    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpPost(Router.ApplicationUserRouting.Create)]
        public async Task<IActionResult> RegisterUser([FromBody] AddUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);
            return NewResult(response);
        }

        [HttpGet(Router.ApplicationUserRouting.Paginated)]
        public async Task<IActionResult> GetPaginatedUsers([FromQuery] GetPagintedUserQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet(Router.ApplicationUserRouting.GetByID)]
        public async Task<IActionResult> GetUSerById([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetSingleUserByIdQuery(id));
            return NewResult(res);
        }

    }
}
