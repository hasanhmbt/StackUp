using FluentValidation;
using StackUp.Application.Commands.ProductCommands;

namespace StackUp.Application.Validators.Product
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Product Id must be greater than 0.");

            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("SupplierId must be greater than 0.");

            RuleFor(x => x.SellingPrice)
                .GreaterThan(0).WithMessage("Selling price must be greater than 0.");

            RuleFor(x => x.PurchasePrice)
                .GreaterThan(0).WithMessage("Purchase price must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
        }
    }
}
