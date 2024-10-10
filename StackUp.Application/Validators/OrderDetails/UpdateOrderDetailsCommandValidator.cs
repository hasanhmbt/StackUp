using FluentValidation;
using StackUp.Application.Commands.OrderDetails;

namespace StackUp.Application.Validators.OrderDetails
{
    public class UpdateOrderDetailsCommandValidator : AbstractValidator<UpdateOrderDetailsCommand>
    {
        public UpdateOrderDetailsCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order details Id must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
