using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Authentication.Command.Model;
using School.Core.Feature.Students.Commands.Validation;
using School.Core.Resources;

namespace School.Core.Feature.Authentication.Command.Validation
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        private readonly IStringLocalizer<SharedResources> _Localizer;

        public SignInValidator(IStringLocalizer<SharedResources> localizer)
        {
            _Localizer = localizer;
        }

        public void ApplycustomValidation()

        {
            RuleFor(x => x.UserName)
                  .ApplyNullEmptyRule(_Localizer);

            RuleFor(f => f.Password)
             .ApplyNullEmptyRule(_Localizer);

        }

    }
}
