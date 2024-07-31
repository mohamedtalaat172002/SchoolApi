using MediatR;
using School.Core.Feature.Students.Queries.Result;

namespace School.Core.Feature.Students.Queries.Model
{
    public class GetAllStudentQuery : IRequest<Base.Response<IQueryable<GetAllStudentsDto>>>
    {
    }
}
