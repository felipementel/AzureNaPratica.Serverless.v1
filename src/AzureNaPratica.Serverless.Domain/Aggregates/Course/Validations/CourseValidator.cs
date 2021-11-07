using FluentValidation;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Course.Validations
{
    public class StudentValidator : AbstractValidator<Entities.Course>
    {
        public StudentValidator()
        {
            RuleSet("new", () =>
            {
                RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");
            });

            RuleSet("update", () =>
            {
                RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");
            });
        }
    }
}
