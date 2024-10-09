using FluentValidation;
using StackUp.UI.Models.Inventories;

namespace StackUp.UI.Validators.Inventories
{
    public class AdjustInventoryModelValidator : AbstractValidator<AdjustInventoryModel>
    {
        public AdjustInventoryModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Product ID must be a positive number.");

            RuleFor(x => x.AdjustmentAmount)
                .GreaterThanOrEqualTo(0).WithMessage("Adjustment amount cannot be negative.");
        }
    }
}
