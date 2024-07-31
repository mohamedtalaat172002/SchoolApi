using FluentValidation;
using School.Core.Feature.Students.Commands.Model;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Commands.Validation
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        public AddStudentValidator(IStudentService studentService)
        {
            this.ApplyValidationRules();
            ApplyCustomValidation();
            this._studentService = studentService;
        }


        public void ApplyCustomValidation()
        {
            RuleFor(x => x.Name)
              .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
              .WithMessage("Name is Already Exists");

        }
    }
}
