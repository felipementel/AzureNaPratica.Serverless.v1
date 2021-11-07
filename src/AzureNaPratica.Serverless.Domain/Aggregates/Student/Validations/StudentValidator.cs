using FluentValidation;

namespace AzureNaPratica.Serverless.Domain.Aggregates.Student.Validations
{
    public class StudentValidator : AbstractValidator<Entities.Student>
    {
        public StudentValidator()
        {
            RuleSet("new", () =>
            {
                RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");
            });
        }
    }
}
