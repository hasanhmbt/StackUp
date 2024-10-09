using FluentValidation;
using StackUp.UI.Models.Orders;

namespace StackUp.UI.Validators.Orders
{
    public class CreateOrderModelValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderModelValidator()
        {
            RuleFor(x => x.OrderNumber)
                .GreaterThan(0).WithMessage("Order number must be a positive number.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Supplier ID must be a positive number.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("Order date is required.")
                .LessThanOrEqualTo(DateTime.Today).WithMessage("Order date cannot be in the future.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID must be a positive number.");

            RuleFor(x => x.OrderDetails)
                .NotEmpty().WithMessage("At least one order detail is required.")
                .Must(details => details != null && details.Any())
                .WithMessage("Order must contain at least one order detail.");

            RuleForEach(x => x.OrderDetails).SetValidator(new CreateOrderDetailsModelValidator());
        }
    }

    public class CreateOrderDetailsModelValidator : AbstractValidator<CreateOrderDetailsModel>
    {
        public CreateOrderDetailsModelValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product ID must be a positive number.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1.");
        }
    }
}
