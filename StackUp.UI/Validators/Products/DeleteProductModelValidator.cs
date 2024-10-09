using FluentValidation;
using StackUp.UI.Models.Products;

namespace StackUp.UI.Validators.Products
{
    public class DeleteProductModelValidator : AbstractValidator<DeleteProductModel>
    {
        public DeleteProductModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Product ID must be a positive number.");
        }
    }
}
