using FluentValidation;
using StackUp.UI.Models.Customers;

namespace StackUp.UI.Validators.Customers
{
    public class DeleteCustomerModelValidator : AbstractValidator<DeleteCustomerModel>
    {
        public DeleteCustomerModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Customer ID must be a positive number.");
        }
    }
}
