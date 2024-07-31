using AutoMapper;
using MediatR;
using School.Core.Base;
using School.Core.Feature.Students.Commands.Model;
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
        private readonly IMapper mapper;
        public StudentcommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            this.mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var std = mapper.Map<Student>(request);
            string res = await _studentService.AddStudent(std);
            return Created(res);
        }

        public async Task<Response<string>> Handle(EditeStudentCommand request, CancellationToken cancellationToken)
        {
            var std = mapper.Map<Student>(request);
            string res = await _studentService.UpdateStudent(std);
            return Created(res);
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var Std = _studentService.GetStudentById(request.id);
            if (Std == null)
                return NotFound<String>($"No student with id:{request.id}");
            await _studentService.DeleteStudent(request.id);
            return Deleted<String>();

        }
    }
}
