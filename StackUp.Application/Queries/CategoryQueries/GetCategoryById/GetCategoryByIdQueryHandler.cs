// Namespace: StackUp.Application.QueryHandlers.CategoryHandlers
using AutoMapper;
using MediatR;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.CategoryQueries;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.QueryHandlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);
            if (category == null)
            {
                // Handle not found
                return null;
            }

            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
