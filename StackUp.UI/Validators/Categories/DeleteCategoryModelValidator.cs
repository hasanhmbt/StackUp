using FluentValidation;
using StackUp.UI.Models.Categories;

namespace StackUp.UI.Validators.Categories
{
    public class DeleteCategoryModelValidator : AbstractValidator<DeleteCategoryModel>
    {
        public DeleteCategoryModelValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Category ID must be a positive number.");
        }
    }
}
