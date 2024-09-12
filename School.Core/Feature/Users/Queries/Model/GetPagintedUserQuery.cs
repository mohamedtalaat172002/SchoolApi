using MediatR;
using School.Core.Base;
using School.Core.Feature.Users.Queries.Result;
using School.Core.Wrapper;

namespace School.Core.Feature.Users.Queries.Model
{
    public class GetPagintedUserQuery : IRequest<Response<PaginatedResult<GetPaginatedListOfUsersDto>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
