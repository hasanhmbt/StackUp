using FluentValidation;
using StackUp.Application.Commands.CustomerCommands;

namespace StackUp.Application.Validators.Customer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Customer Id must be greater than 0.");
        }
    }
}
