using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format")
            .MaximumLength(50).WithMessage("Email address should not exceed 50 characters");

        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");
    }
}
