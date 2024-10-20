using AutoMapper;
using MediatR;
using StackUp.Application.Commands.CategoryCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = await _unitOfWork.Repository<Category>().GetByIdAsync(request.Id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with Id {request.Id} not found.");
            }

            _mapper.Map(request, category);
            _unitOfWork.Repository<Category>().Update(category);
            await _unitOfWork.CommitAsync();

            var updatedCategory = await _unitOfWork.Repository<Category>().GetByIdAsync(category.Id);
            return _mapper.Map<CategoryDTO>(updatedCategory);

        }
    }
}
