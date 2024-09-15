using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Students.Commands.Validation;
using School.Core.Feature.Users.Command.Model;
using School.Core.Resources;

namespace School.Core.Feature.Users.Command.Validation
{
    public static class UserValidationExtention
    {

        public static void ApplyUserValidation<T>(this AbstractValidator<T> validator, IStringLocalizer<SharedResources> _localizer) where T : IUserCommand
        {
            validator.RuleFor(f => f.FullName)
               .ApplyNullEmptyRule(_localizer)
               .MaximumLength(100)
               .WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            validator.RuleFor(f => f.Address)
                .MaximumLength(250)
                .WithMessage(_localizer[SharedResourcesKeys.MaxLength250]);

            validator.RuleFor(f => f.Country)
                .MaximumLength(100)
                .WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            validator.RuleFor(f => f.UserName)
                .ApplyNullEmptyRule(_localizer)
                .MaximumLength(50)
                .WithMessage(_localizer[SharedResourcesKeys.MaxLength50]);

            validator.RuleFor(f => f.Email)
                .ApplyNullEmptyRule(_localizer);

            validator.RuleFor(f => f.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .When(f => !string.IsNullOrEmpty(f.PhoneNumber))
                .WithMessage(_localizer[SharedResourcesKeys.MaxLengthPhone]);

        }
    }
}
