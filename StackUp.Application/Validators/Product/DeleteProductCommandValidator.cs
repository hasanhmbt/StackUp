using FluentValidation;
using StackUp.Application.Commands.ProductCommands;

namespace StackUp.Application.Validators.Product
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Product Id must be greater than 0.");
        }
    }
}
