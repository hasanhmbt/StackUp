using FluentValidation;
using StackUp.UI.Models.Customers;

namespace StackUp.UI.Validators.Customers
{
    public class EditCustomerModelValidator : AbstractValidator<EditCustomerModel>
    {
        public EditCustomerModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Customer ID must be a positive number.");

            RuleFor(x => x.CustomerName)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name must not exceed 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");

            RuleFor(x => x.ContactInfo)
                .NotNull().WithMessage("Contact information is required.");

            When(x => x.ContactInfo != null, () =>
            {
                RuleFor(x => x.ContactInfo.Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Invalid email format.");

                RuleFor(x => x.ContactInfo.Phone)
                    .NotEmpty().WithMessage("Phone number is required.")
                     .WithMessage("Invalid phone number format.");
            });
        }
    }
}
