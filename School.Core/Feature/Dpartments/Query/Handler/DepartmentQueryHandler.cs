using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Dpartments.Query.Model;
using School.Core.Feature.Dpartments.Query.Result;
using School.Core.Resources;
using School.Core.Wrapper;
using School.Data.Models;
using School.Service.Abstract;
using System.Linq.Expressions;

namespace School.Core.Feature.Dpartments.Query.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
            IRequestHandler<GetSingleDeptById, Response<GetSigleDeptbyIdDto>>
    {

        private readonly IDepartementService _departementService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IStudentService _studentService;
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper, IDepartementService departementService, IStudentService studentService) : base(stringLocalizer)
        {
            _mapper = mapper;
            _departementService = departementService;
            _stringLocalizer = stringLocalizer;
            _studentService = studentService;
        }

        public async Task<Response<GetSigleDeptbyIdDto>> Handle(GetSingleDeptById request, CancellationToken cancellationToken)
        {

            var dept = await _departementService.GetDeptById(request.id);
            if (dept == null)
                return NotFound<GetSigleDeptbyIdDto>();
            //pagination
            Expression<Func<Student, StudentResponse>> exp = e =>
            new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var stds = _studentService.GetStudentsByDeptId(request.id);
            var stdPaginated = await stds.Select(exp).ToPaginatedListAsync(request.StudentPageNumber, request.stduentPagesize);

            //Mapping
            var deptMapped = _mapper.Map<GetSigleDeptbyIdDto>(dept);
            deptMapped.StudentsList = stdPaginated;
            return Success(deptMapped);
        }
    }
}
