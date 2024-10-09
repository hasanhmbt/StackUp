using AutoMapper;
using MediatR;
using StackUp.Application.Commands.ProductCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {request.Id} not found.");
            }

            _mapper.Map(request, product);
            _unitOfWork.Repository<Product>().Update(product);
            await _unitOfWork.CommitAsync();

            var updatedProduct = await _unitOfWork.Repository<Product>().GetByIdAsync(product.Id);
            return _mapper.Map<ProductDTO>(updatedProduct);
        }
    }
}
