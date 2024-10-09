using FluentValidation;
using StackUp.UI.Models.Suppliers;

namespace StackUp.UI.Validators.Suppliers
{
    public class DeleteSupplierModelValidator : AbstractValidator<DeleteSupplierModel>
    {
        public DeleteSupplierModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Supplier ID must be a positive number.");
        }
    }
}
