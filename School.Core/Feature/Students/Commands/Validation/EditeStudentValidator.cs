using FluentValidation;
using School.Core.Feature.Students.Commands.Model;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Commands.Validation
{
    public class EditeStudentValidator : AbstractValidator<EditeStudentCommand>
    {
        private readonly IStudentService _studentService;
        public EditeStudentValidator(IStudentService studentService)
        {
            this.ApplyValidationRules();
            ApplyCustomValidation();
            this._studentService = studentService;
        }


        public void ApplyCustomValidation()
        {
            RuleFor(x => x.Name)
               .MustAsync(async (Model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, Model.StudID))
               .WithMessage("Name is Already Exists");
        }


    }
}
