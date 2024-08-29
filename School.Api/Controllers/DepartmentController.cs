using Microsoft.AspNetCore.Mvc;
using School.Api.Base;
using School.Core.Feature.Dpartments.Query.Model;

namespace School.Api.Controllers
{

    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetByID)]
        public async Task<IActionResult> GetSingleDepartmentById([FromQuery] GetSingleDeptById query)

        {
            var res = await _mediator.Send(query);
            return NewResult(res);
        }

    }
}
