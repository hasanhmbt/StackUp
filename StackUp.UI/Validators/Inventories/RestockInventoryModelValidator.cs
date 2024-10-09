using FluentValidation;
using StackUp.UI.Models.Inventories;

namespace StackUp.UI.Validators.Inventories
{
    public class RestockInventoryModelValidator : AbstractValidator<RestockInventoryModel>
    {
        public RestockInventoryModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Inventory ID must be a positive number.");

            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Restock quantity must be at least 1.");
        }
    }
}
