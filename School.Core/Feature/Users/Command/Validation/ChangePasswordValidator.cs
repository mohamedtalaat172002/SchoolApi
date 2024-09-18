using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Students.Commands.Validation;
using School.Core.Feature.Users.Command.Model;
using School.Core.Resources;

namespace School.Core.Feature.Users.Command.Validation
{
    public class ChangePasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
    {
        private readonly IStringLocalizer<SharedResources> _Localizer;

        public ChangePasswordValidator(IStringLocalizer<SharedResources> localizer)
        {
            _Localizer = localizer;
            ApplyCustomValidation();
        }



        public void ApplyCustomValidation()
        {
            RuleFor(f => f.CurrentPassword)
            .ApplyNullEmptyRule(_Localizer);

            RuleFor(f => f.NewPassword)
            .ApplyNullEmptyRule(_Localizer);

            RuleFor(f => f.ConfirmPassword)
            .ApplyNullEmptyRule(_Localizer)
                .Equal(f => f.NewPassword)
                .WithMessage(_Localizer[SharedResourcesKeys.PasswordsMustMatch]);

        }
    }
}
