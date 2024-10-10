using FluentValidation;
using StackUp.Application.Commands.SupplierCommands;

namespace StackUp.Application.Validators.Supplier
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x => x.SupplierName)
                .NotEmpty().WithMessage("Supplier name is required.")
                .Length(2, 50).WithMessage("Supplier name must be between 2 and 50 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email is required.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be valid (E.164 format).");
        }
    }
}
