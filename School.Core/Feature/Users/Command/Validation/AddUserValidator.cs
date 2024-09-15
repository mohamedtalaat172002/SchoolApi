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
            ApplyCustomValidation();
            this.ApplyUserValidation(_Localizer);
        }
        public void ApplyCustomValidation()
        {
            RuleFor(f => f.Password)
            .ApplyNullEmptyRule(_Localizer);

            RuleFor(f => f.ConfirmPassword)
            .ApplyNullEmptyRule(_Localizer)
                .Equal(f => f.Password)
                .WithMessage(_Localizer[SharedResourcesKeys.PasswordsMustMatch]);

        }



    }
}
