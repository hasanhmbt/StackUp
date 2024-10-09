using FluentValidation;
using StackUp.UI.Models.Suppliers;

namespace StackUp.UI.Validators.Suppliers
{
    public class CreateSupplierModelValidator : AbstractValidator<CreateSupplierModel>
    {
        public CreateSupplierModelValidator()
        {
            RuleFor(x => x.SupplierName)
                .NotEmpty().WithMessage("Supplier name is required.")
                .MaximumLength(100).WithMessage("Supplier name must not exceed 100 characters.");

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

                RuleFor(x => x.ContactInfo.Address)
                    .NotEmpty().WithMessage("Address is required.")
                    .MaximumLength(200).WithMessage("Address must not exceed 200 characters.");
            });
        }
    }
}
