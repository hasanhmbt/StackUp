using FluentValidation;
using StackUp.Application.Commands.InventoryCommands;

namespace StackUp.Application.Validators.Inventory
{
    public class CreateInventoryCommandValidator : AbstractValidator<CreateInventoryCommand>
    {
        public CreateInventoryCommandValidator()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.QuantityOnHand)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity on hand must be zero or greater.");

            RuleFor(x => x.ReorderLevel)
                .GreaterThanOrEqualTo(0).WithMessage("Reorder level must be zero or greater.");
        }
    }
}
