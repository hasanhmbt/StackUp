using FluentValidation;
using StackUp.Application.Commands.SupplierCommands;

namespace StackUp.Application.Validators.Supplier
{
    public class DeleteSupplierCommandValidator : AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Supplier Id must be greater than 0.");
        }
    }
}
