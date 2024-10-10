using FluentValidation;
using StackUp.Application.Commands.InventoryCommands;

namespace StackUp.Application.Validators.Inventory
{
    public class UpdateInventoryCommandValidator : AbstractValidator<UpdateInventoryCommand>
    {
        public UpdateInventoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Inventory Id must be greater than 0.");

            //RuleFor(x => x.ProductId)
            //    .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.QuantityOnHand)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity on hand must be zero or greater.");

            RuleFor(x => x.ReorderLevel)
                .GreaterThanOrEqualTo(0).WithMessage("Reorder level must be zero or greater.");
        }
    }
}
