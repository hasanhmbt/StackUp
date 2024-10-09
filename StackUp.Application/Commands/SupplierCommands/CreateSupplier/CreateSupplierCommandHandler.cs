// File: StackUp.Application/CommandHandlers/SupplierHandlers/CreateSupplierCommandHandler.cs
using AutoMapper;
using MediatR;
using StackUp.Application.Commands.SupplierCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.SupplierHandlers
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, SupplierDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = _mapper.Map<Supplier>(request);
            await _unitOfWork.Repository<Supplier>().AddAsync(supplier);
            await _unitOfWork.CommitAsync();

            var createdSupplier = await _unitOfWork.Repository<Supplier>().GetByIdAsync(supplier.Id);
            return _mapper.Map<SupplierDTO>(createdSupplier);
        }
    }
}
