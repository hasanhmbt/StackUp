using FluentValidation;
using StackUp.UI.Models.Categories;

namespace StackUp.UI.Validators.Categories
{
    public class EditCategoryModelValidator : AbstractValidator<EditCategoryModel>
    {
        public EditCategoryModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Category ID must be a positive number.");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .MaximumLength(100).WithMessage("Category name must not exceed 100 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.ParentId)
                .GreaterThan(0).When(x => x.ParentId.HasValue)
                .WithMessage("Parent ID must be a positive number if provided.");
        }
    }
}
