using FluentValidation;
using StackUp.UI.Models.OrderDetails;

namespace StackUp.UI.Validators.OrderDetails
{
    public class EditOrderDetailsModelValidator : AbstractValidator<EditOrderDetailsModel>
    {
        public EditOrderDetailsModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order Details ID must be a positive number.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product ID must be a positive number.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be at least 1.");
        }
    }
}
