using AutoMapper;
using MediatR;
using School.Core.Base;
using School.Core.Feature.Students.Queries.Model;
using School.Core.Feature.Students.Queries.Result;
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

        public StudentQueryHandler(IMapper mapper, IStudentService studentService)
        {

            _mapper = mapper;
            _studentService = studentService;
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
                return NotFound<GetSingleStudentDto>($"No student with id:{request.id}");

            var stdMapped = _mapper.Map<GetSingleStudentDto>(Std);
            return Success(stdMapped);
        }

        public async Task<PaginatedResult<GetStudentsPaginatedResponse>> Handle(GetStudentsPaginatedQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentsPaginatedResponse>> exp = e =>
            new(e.StudID, e.Name, e.Address, e.Department.DName);
            var stds = await _studentService.GetAllStudents();
            var stdPaginated = await stds.Select(exp).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return (stdPaginated);
        }


    }
}
