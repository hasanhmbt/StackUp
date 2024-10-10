using FluentValidation;
using StackUp.Application.Commands.OrderDetailsCommands;

namespace StackUp.Application.Validators.OrderDetails
{
    public class DeleteOrderDetailsCommandValidator : AbstractValidator<DeleteOrderDetailsCommand>
    {
        public DeleteOrderDetailsCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order details Id must be greater than 0.");
        }
    }
}
