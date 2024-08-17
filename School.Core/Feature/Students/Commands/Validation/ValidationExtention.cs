using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Students.Commands.Model;
using School.Core.Resources;

namespace School.Core.Feature.Students.Commands.Validation
{
    public static class ValidationExtention
    {


        public static IRuleBuilderOptions<T, TProperty> ApplyNullEmptyRule<T, TProperty>
            (this IRuleBuilder<T, TProperty> ruleBuilder,
            IStringLocalizer<SharedResources> _localizer)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage($" {_localizer[SharedResourcesKeys.NotEmpty]}")
                .NotNull()
                .WithMessage($"{_localizer[SharedResourcesKeys.NotNull]}");
        }

        public static void ApplyValidationRules<T>(this AbstractValidator<T> validator, IStringLocalizer<SharedResources> _localizer) where T : IStudentCommand
        {
            validator.RuleFor(student => student.NameAr)
                .ApplyNullEmptyRule(_localizer)
                .MaximumLength(100)
                 .WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            validator.RuleFor(student => student.NameEn)
                .ApplyNullEmptyRule(_localizer)
                .MaximumLength(100)
                 .WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);


            validator.RuleFor(x => x.Address)
                .ApplyNullEmptyRule(_localizer)
                .MaximumLength(100)
                .WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            validator.RuleFor(x => x.Phone)
                .ApplyNullEmptyRule(_localizer)
                .Matches(@"^\d{11}$")
                .WithMessage(_localizer[SharedResourcesKeys.MaxLengthPhone]);

            validator.RuleFor(x => x.DID)
                .ApplyNullEmptyRule(_localizer)
                .InclusiveBetween(1, 3)
                .WithMessage(_localizer[SharedResourcesKeys.DepartmentNums]);
        }



    }
}
