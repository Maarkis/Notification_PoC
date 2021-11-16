using Application.Domain;
using FluentValidation;

namespace Application.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-mail cannot be empty")
                .EmailAddress().WithMessage("Invalid email");
        }
    }
}