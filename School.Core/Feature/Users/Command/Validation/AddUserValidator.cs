using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Students.Commands.Validation;
using School.Core.Feature.Users.Command.Model;
using School.Core.Resources;

namespace School.Core.Feature.Users.Command.Validation
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _Localizer;

        public AddUserValidator(IStringLocalizer<SharedResources> localizer)
        {
            _Localizer = localizer;
            ApplyUserValidationRules(_Localizer);
        }

        public void ApplyUserValidationRules(IStringLocalizer<SharedResources> _localizer)
        {
            RuleFor(f => f.FullName)
           .ApplyNullEmptyRule(_localizer)
           .MaximumLength(100)
           .WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            RuleFor(f => f.Address)
                .MaximumLength(250)
                .WithMessage(_localizer[SharedResourcesKeys.MaxLength250]);

            RuleFor(f => f.Country)
                .MaximumLength(100)
                .WithMessage(_localizer[SharedResourcesKeys.MaxLength100]);

            RuleFor(f => f.UserName)
                .ApplyNullEmptyRule(_localizer)
                .MaximumLength(50)
                .WithMessage(_localizer[SharedResourcesKeys.MaxLength50]);

            RuleFor(f => f.Email)
                .ApplyNullEmptyRule(_localizer);

            RuleFor(f => f.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$")
                .When(f => !string.IsNullOrEmpty(f.PhoneNumber))
                .WithMessage(_localizer[SharedResourcesKeys.MaxLengthPhone]);

            RuleFor(f => f.Password)
                .ApplyNullEmptyRule(_localizer);

            RuleFor(f => f.ConfirmPassword)
                .Equal(f => f.Password)
                .WithMessage(_localizer[SharedResourcesKeys.PasswordsMustMatch]);

        }
    }
}
