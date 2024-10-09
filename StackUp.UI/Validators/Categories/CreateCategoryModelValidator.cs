using FluentValidation;
using StackUp.UI.Models.Categories;

namespace StackUp.UI.Validators.Categories
{
    public class CreateCategoryModelValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryModelValidator()
        {
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
