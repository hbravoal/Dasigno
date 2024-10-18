using FluentValidation;

namespace Dasigno.Application.User.Queries.GetAll;

public class GetAllUsersQueryValidator : AbstractValidator<GetUsersParameter>
{
    public GetAllUsersQueryValidator()
    {
        RuleFor(p => p.PageNumber)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
        RuleFor(p => p.PageSize)
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");

        RuleFor(p => p.FieldToSearch)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.")
            .When(p => !string.IsNullOrEmpty(p.FieldToSearch));
    }
}