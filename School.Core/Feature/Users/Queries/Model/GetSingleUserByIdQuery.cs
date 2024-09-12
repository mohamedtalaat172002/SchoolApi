using MediatR;
using School.Core.Base;
using School.Core.Feature.Users.Queries.Result;

namespace School.Core.Feature.Users.Queries.Model
{
    public class GetSingleUserByIdQuery : IRequest<Response<GetSingleUserByIdDto>>
    {
        public int Id { get; set; }

        public GetSingleUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
