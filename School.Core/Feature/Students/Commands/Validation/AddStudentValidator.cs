using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Students.Commands.Model;
using School.Core.Resources;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Commands.Validation
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _Localizer;
        public AddStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            this._Localizer = stringLocalizer;
            this.ApplyValidationRules(_Localizer);
            ApplyCustomValidation();
            this._studentService = studentService;

        }


        public void ApplyCustomValidation()
        {
            RuleFor(x => x.NameAr)
              .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameArExist(Key))
              .WithMessage("الاسم متواجد بالفعل لايمكن اضافه نفس الاسم مرتين ");


            RuleFor(x => x.NameEn)
             .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameEnExist(Key))
             .WithMessage("Name is Already Exists,can't add the same name twice");

        }
    }
}
