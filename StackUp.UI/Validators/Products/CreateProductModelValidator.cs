using FluentValidation;
using StackUp.UI.Models.Products;

namespace StackUp.UI.Validators.Products
{
    public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductModelValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("Supplier ID must be a positive number.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Category ID must be a positive number.");
        }
    }
}
