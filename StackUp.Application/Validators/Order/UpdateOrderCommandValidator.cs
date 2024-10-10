using FluentValidation;
using StackUp.Application.Commands.OrderCommands;

UpdateOrderCommandValidator ausing FluentValidation;
using StackUp.Application.Commands.OrderCommands;

namespace StackUp.Application.Validators.Order
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order Id must be greater than 0.");

            RuleFor(x => x.OrderNumber)
                .GreaterThan(0).WithMessage("Order number must be greater than 0.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Supplier Id must be greater than 0.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Customer Id must be greater than 0.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("Order date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.");

            RuleFor(x => x.OrderDetails)
                .NotEmpty().WithMessage("Order must contain at least one order detail.");

            RuleForEach(x => x.OrderDetails).ChildRules(orderDetails =>
            {
                orderDetails.RuleFor(od => od.ProductId)
                    .GreaterThan(0).WithMessage("Product Id must be greater than 0.");

                orderDetails.RuleFor(od => od.Quantity)
                    .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            });
        }
    }
}
