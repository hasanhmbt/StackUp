using FluentValidation;
using StackUp.Application.Commands.ProductCommands;

namespace StackUp.Application.Validators.Product
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(2, 100).WithMessage("Product name must be between 2 and 100 characters.");

            RuleFor(x => x.SupplierId)
                .GreaterThan(0).WithMessage("SupplierId must be greater than 0.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
        }
    }
}
