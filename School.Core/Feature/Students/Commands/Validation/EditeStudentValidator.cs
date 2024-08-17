using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Students.Commands.Model;
using School.Core.Resources;
using School.Service.Abstract;

namespace School.Core.Feature.Students.Commands.Validation
{
    public class EditeStudentValidator : AbstractValidator<EditeStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> stringLocalizer;
        public EditeStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this.ApplyValidationRules(stringLocalizer);
            ApplyCustomValidation();
            this._studentService = studentService;

        }


        public void ApplyCustomValidation()
        {
            RuleFor(x => x.NameEn)
               .MustAsync(async (Model, Key, CancellationToken) => !await _studentService.IsNameEnExistExcludeSelf(Key, Model.StudID))
               .WithMessage("Name is Already Exists");

            RuleFor(x => x.NameAr)
               .MustAsync(async (Model, Key, CancellationToken) => !await _studentService.IsNameArExistExcludeSelf(Key, Model.StudID))
               .WithMessage("الاسم بالفعل متواجد لايمكن التعديل الي اسم متواجد");
        }


    }
}
