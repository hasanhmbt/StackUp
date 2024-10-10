using FluentValidation;
using StackUp.Application.Commands.CustomerCommands;

namespace StackUp.Application.Validators.Customer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Customer Id must be greater than 0.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .Length(2, 50).WithMessage("Customer name must be between 2 and 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be valid (E.164 format).");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(100).WithMessage("Address must not exceed 100 characters.");
        }
    }
}
