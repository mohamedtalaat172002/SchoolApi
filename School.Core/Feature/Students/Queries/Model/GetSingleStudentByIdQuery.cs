using MediatR;
using School.Core.Base;
using School.Core.Feature.Students.Queries.Result;

namespace School.Core.Feature.Students.Queries.Model
{
    public class GetSingleStudentByIdQuery : IRequest<Response<GetSingleStudentDto>>
    {
        public int id { get; set; }
        public GetSingleStudentByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
