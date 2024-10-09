using FluentValidation;
using StackUp.UI.Models.Orders;

namespace StackUp.UI.Validators.Orders
{
    public class DeleteOrderModelValidator : AbstractValidator<DeleteOrderModel>
    {
        public DeleteOrderModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order ID must be a positive number.");
        }
    }
}
