using FluentValidation;
using StackUp.UI.Models.OrderDetails;

namespace StackUp.UI.Validators.OrderDetails
{
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
