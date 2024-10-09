using FluentValidation;
using StackUp.UI.Models.OrderDetails;

namespace StackUp.UI.Validators.OrderDetails
{
    public class DeleteOrderDetailsModelValidator : AbstractValidator<DeleteOrderDetailsModel>
    {
        public DeleteOrderDetailsModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Order Details ID must be a positive number.");
        }
    }
}
