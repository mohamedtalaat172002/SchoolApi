using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using School.Core.Base;
using School.Core.Feature.Students.Commands.Model;
using School.Core.Resources;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Commands.Handler
{
    public class StudentcommandHandler : ResponseHandler
        , IRequestHandler<AddStudentCommand, Response<String>>
        , IRequestHandler<EditeStudentCommand, Response<String>>
        , IRequestHandler<DeleteStudentCommand, Response<String>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        public StudentcommandHandler(IStudentService studentService,
            IMapper mapper
            , IStringLocalizer<SharedResources> sharedResources) : base(sharedResources)
        {
            _studentService = studentService;
            this._mapper = mapper;
            _sharedResources = sharedResources;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var std = _mapper.Map<Student>(request);
            string res = await _studentService.AddStudent(std);
            return Created(res);
        }

        public async Task<Response<string>> Handle(EditeStudentCommand request, CancellationToken cancellationToken)
        {
            //check the existence
            var std = _studentService.GetStudentByIdWithOutDept(request.StudID);
            if (std == null) return NotFound<String>($"No student with id:{request.StudID}");
            //maping
            var StdMapped = _mapper.Map<Student>(request);
            //call servcice
            var res = await _studentService.UpdateStudent(StdMapped);
            //return response
            return Updated<String>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var Std = await _studentService.GetStudentByIdWithOutDept(request.id);
            if (Std == null)
                return NotFound<String>($"No student with id:{request.id}");
            await _studentService.DeleteStudent(Std);
            return Deleted<String>();

        }
    }
}
