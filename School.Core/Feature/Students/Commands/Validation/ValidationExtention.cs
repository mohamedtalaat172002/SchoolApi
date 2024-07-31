using FluentValidation;
using School.Core.Feature.Students.Commands.Model;

namespace School.Core.Feature.Students.Commands.Validation
{
    public static class ValidationExtention
    {
        public static IRuleBuilderOptions<T, TProperty> ApplyNullEmptyRule<T, TProperty>(
       this IRuleBuilder<T, TProperty> ruleBuilder, string propertyName)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage($"{propertyName} cannot be empty")
                .NotNull()
                .WithMessage($"{propertyName} cannot be null");
        }

        public static void ApplyValidationRules<T>(this AbstractValidator<T> validator) where T : IStudentCommand
        {
            validator.RuleFor(student => student.Name)
                .ApplyNullEmptyRule("Name")
                .MaximumLength(50)
                .WithMessage("Maximum length for name is 50");

            validator.RuleFor(x => x.Address)
                .ApplyNullEmptyRule("Address")
                .MaximumLength(100)
                .WithMessage("Address can't be more than 100 char");

            validator.RuleFor(x => x.Phone)
                .ApplyNullEmptyRule("Phone")
                .Matches(@"^\d{5}$")
                .WithMessage("Phone number must be 5 digits long");

            validator.RuleFor(x => x.DID)
                .ApplyNullEmptyRule("Department ID")
                .InclusiveBetween(1, 3)
                .WithMessage("The IDs are: 1 for CS, 2 for IT, 3 for IS");
        }



    }
}
