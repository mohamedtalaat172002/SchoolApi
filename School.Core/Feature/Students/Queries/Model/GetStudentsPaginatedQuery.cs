using MediatR;
using School.Core.Feature.Students.Queries.Result;
using School.Core.Wrapper;

namespace School.Core.Feature.Students.Queries.Model
{
    public class GetStudentsPaginatedQuery : IRequest<PaginatedResult<GetStudentsPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public String[]? OrderBy { get; set; }
        public string? Search { get; set; }

    }
}
