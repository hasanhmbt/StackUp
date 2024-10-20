using AutoMapper;
using MediatR;
using StackUp.Application.Commands.CategoryCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = _mapper.Map<Category>(request);
            await _unitOfWork.Repository<Category>().AddAsync(category);
            await _unitOfWork.CommitAsync();

            var createdCategory = await _unitOfWork.Repository<Category>().GetByIdAsync(category.Id);
            return _mapper.Map<CategoryDTO>(createdCategory);

        }
    }
}
