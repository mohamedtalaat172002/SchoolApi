using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Students.Queries.Model;
using School.Core.Feature.Students.Queries.Result;
using School.Core.Resources;
using School.Core.Wrapper;
using School.Data.Models;
using School.Service.Abstract;
using System.Linq.Expressions;

namespace School.Core.Feature.Students.Queries.Handler
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetAllStudentQuery, Response<IQueryable<GetAllStudentsDto>>>,
        IRequestHandler<GetSingleStudentByIdQuery, Response<GetSingleStudentDto>>,
        IRequestHandler<GetStudentsPaginatedQuery, PaginatedResult<GetStudentsPaginatedResponse>>

    {

        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public StudentQueryHandler(IMapper mapper,
            IStudentService studentService,
            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {

            _mapper = mapper;
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
        }

        public async Task<Response<IQueryable<GetAllStudentsDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            //call the service
            var stds = await _studentService.GetAllStudents();
            //map to dto
            var stdsMap = _mapper.Map<IEnumerable<GetAllStudentsDto>>(stds).AsQueryable();
            // return dto 

            return Success(stdsMap);


        }



        public async Task<Response<GetSingleStudentDto>> Handle(GetSingleStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var Std = await _studentService.GetStudentByIdIncludeDept(request.id);
            if (Std == null)
                return NotFound<GetSingleStudentDto>();

            var stdMapped = _mapper.Map<GetSingleStudentDto>(Std);
            return Success(stdMapped);
        }

        public async Task<PaginatedResult<GetStudentsPaginatedResponse>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentsPaginatedResponse>> exp = e =>
            new(e.StudID, e.NameEn, e.Address, e.Department.DNameEn);

            var stds = _studentService.GetStudentsWithFilterAndSearch(request.OrderBy, request.Search);
            var stdPaginated = await stds.Select(exp).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return stdPaginated;
        }


    }
}
