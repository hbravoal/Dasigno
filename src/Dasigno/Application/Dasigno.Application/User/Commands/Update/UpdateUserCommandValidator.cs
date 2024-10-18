using FluentValidation;

namespace Dasigno.Application.User.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .Matches("^[a-zA-Z]+$").WithMessage("{PropertyName} must not contain numbers.");

            RuleFor(p => p.MiddleName)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .Matches("^[a-zA-Z]*$").WithMessage("{PropertyName} must not contain numbers.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .Matches("^[a-zA-Z]+$").WithMessage("{PropertyName} must not contain numbers.");

            RuleFor(p => p.SecondLastName)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
                .Matches("^[a-zA-Z]*$").WithMessage("{PropertyName} must not contain numbers.");

            RuleFor(p => p.DateOfBirth)
                .NotNull().WithMessage("{PropertyName} is required.");

            RuleFor(p => p.Salary)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
   
        }
    }
}
