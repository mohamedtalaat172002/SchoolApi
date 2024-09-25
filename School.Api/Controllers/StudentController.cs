using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Feature.Students.Commands.Model;
using School.Core.Feature.Students.Queries.Model;

namespace School.Api.Controllers
{
    [ApiController]

    public class StudentController : AppControllerBase
    {
        [Authorize]
        [HttpGet(Router.StudentRouting.List)]
        public async Task<IActionResult> GetALL()
        {
            var res = await _mediator.Send(new GetAllStudentQuery());
            return NewResult(res);
        }
        [Authorize]
        [HttpGet(Router.StudentRouting.GetByID)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var res = await _mediator.Send(new GetSingleStudentByIdQuery(id));
            return NewResult(res);
        }


        [HttpPost(Router.StudentRouting.Create)]
        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }

        [HttpPut(Router.StudentRouting.Edit)]
        public async Task<IActionResult> EditeStudent([FromBody] EditeStudentCommand command)
        {
            var res = await _mediator.Send(command);
            return NewResult(res);
        }

        [HttpDelete(Router.StudentRouting.Delete)]

        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var res = await _mediator.Send(new DeleteStudentCommand(id));
            return NewResult(res);
        }

        [HttpGet(Router.StudentRouting.Paginated)]
        public async Task<IActionResult> GetStudentPaginated([FromQuery] GetStudentsPaginatedQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }




    }
}
