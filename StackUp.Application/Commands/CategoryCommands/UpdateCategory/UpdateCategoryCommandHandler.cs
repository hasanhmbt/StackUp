using AutoMapper;
using MediatR;
using StackUp.Application.Commands.CategoryCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                // Handle not found
                throw new KeyNotFoundException($"Category with Id {request.Id} not found.");
            }

            _mapper.Map(request, category);
            _categoryRepository.Update(category);

            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
