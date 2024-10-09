using MediatR;
using StackUp.Application.Commands.CategoryCommands;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.CategoryHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                // Handle not found
                throw new KeyNotFoundException($"Category with Id {request.Id} not found.");
            }

            _categoryRepository.Delete(category);

            return Unit.Value;
        }

        Task IRequestHandler<DeleteCategoryCommand>.Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
