using Application.Domain;
using FluentValidation;

namespace Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty")
                .MinimumLength(3).WithMessage("Name must contain at least 3 characters")
                .MaximumLength(60).WithMessage("Name must contain a maximum of 60 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Invalid email");
        }
    }
}