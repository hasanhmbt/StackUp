using FluentValidation;
using StackUp.Application.Commands.OrderCommands;

namespace StackUp.Application.Validators.Order
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order Id must be greater than 0.");
        }
    }
}
