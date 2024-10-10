using FluentValidation;
using StackUp.Application.Commands.InventoryCommands.DeleteInventory;

namespace StackUp.Application.Validators.Inventory
{
    public class DeleteInventoryCommandValidator : AbstractValidator<DeleteInventoryCommand>
    {
        public DeleteInventoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Inventory Id must be greater than 0.");
        }
    }
}
