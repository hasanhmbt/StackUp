using MediatR;
using StackUp.Application.Commands.CategoryCommands;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.CategoryQueries;

namespace StackUp.Application.Services
{
    public class CategoryService
    {
        private readonly IMediator _mediator;

        public CategoryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            return await _mediator.Send(new GetAllCategoriesQuery());
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery(id));
        }

        public async Task AddCategoryAsync(CategoryDTO categoryDto)
        {
            var command = new CreateCategoryCommand(
                categoryDto.CategoryName,
                categoryDto.Description,
                categoryDto.ParentId
            );
            await _mediator.Send(command);
        }

        public async Task UpdateCategoryAsync(CategoryDTO categoryDto)
        {
            var command = new UpdateCategoryCommand(
                categoryDto.Id,
                categoryDto.CategoryName,
                categoryDto.Description,
                categoryDto.ParentId
            );
            await _mediator.Send(command);
        }

        public async Task RemoveCategoryAsync(int id)
        {
            var command = new DeleteCategoryCommand(id);
            await _mediator.Send(command);
        }
    }
}
