using MediatR;
using School.Core.Base;
using School.Core.Feature.Dpartments.Query.Result;

namespace School.Core.Feature.Dpartments.Query.Model
{
    public class GetSingleDeptById : IRequest<Response<GetSigleDeptbyIdDto>>
    {
        public int StudentPageNumber { get; set; }
        public int stduentPagesize { get; set; }
        public int id { get; set; }


    }
}
