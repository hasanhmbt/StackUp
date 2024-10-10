﻿using FluentValidation;
using StackUp.Application.Commands.CategoryCommands;

namespace StackUp.Application.Validators.Category
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Category Id must be greater than 0.");

            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category name is required.")
                .Length(2, 100).WithMessage("Category name must be between 2 and 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot be more than 500 characters.");

            RuleFor(x => x.ParentId)
                .GreaterThanOrEqualTo(0).WithMessage("ParentId must be greater than or equal to 0.");
        }
    }
}