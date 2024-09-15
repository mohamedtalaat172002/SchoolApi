using FluentValidation;
using Microsoft.Extensions.Localization;
using School.Core.Feature.Users.Command.Model;
using School.Core.Resources;

namespace School.Core.Feature.Users.Command.Validation
{
    public class EditeUserValidator : AbstractValidator<EditeUserCommand>
    {
        private readonly IStringLocalizer<SharedResources> _Localizer;

        public EditeUserValidator(IStringLocalizer<SharedResources> localizer)
        {
            _Localizer = localizer;

            this.ApplyUserValidation(_Localizer);
        }

    }
}
