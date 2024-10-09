using AutoMapper;
using MediatR;
using StackUp.Application.Commands.ProductCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _unitOfWork.Repository<Product>().AddAsync(product);
            await _unitOfWork.CommitAsync();

            var createdProduct = await _unitOfWork.Repository<Product>().GetByIdAsync(product.Id);
            return _mapper.Map<ProductDTO>(createdProduct);
        }
    }
}
