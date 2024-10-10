using FluentValidation;
using StackUp.Application.Commands.OrderDetails;

namespace StackUp.Application.Validators.OrderDetails
{
    public class CreateOrderDetailsCommandValidator : AbstractValidator<CreateOrderDetailsCommand>
    {
        public CreateOrderDetailsCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }
}
