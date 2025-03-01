using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;
public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required")
             .EmailAddress().WithMessage("Invalid email address format")
             .MaximumLength(50).WithMessage("Email address should not exceed 50 characters");

        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required")
            ;

        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("Name is required")
            .Length(1, 50).WithMessage("Person Name should be 1 to 50 characters long");

        RuleFor(temp => temp.Gender).NotEmpty().WithMessage("Gender is required")
            .IsInEnum().WithMessage("Invalid gender option");
    }
}
