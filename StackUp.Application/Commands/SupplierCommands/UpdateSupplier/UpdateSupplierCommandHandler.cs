using AutoMapper;
using MediatR;
using StackUp.Application.Commands.SupplierCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.SupplierHandlers
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, SupplierDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SupplierDTO> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await _unitOfWork.Repository<Supplier>().GetByIdAsync(request.Id);
            if (supplier == null)
            {
                throw new KeyNotFoundException($"Supplier with Id {request.Id} not found.");
            }

            _mapper.Map(request, supplier);
            _unitOfWork.Repository<Supplier>().Update(supplier);
            await _unitOfWork.CommitAsync();

            var updatedSupplier = await _unitOfWork.Repository<Supplier>().GetByIdAsync(supplier.Id);
            return _mapper.Map<SupplierDTO>(updatedSupplier);
        }
    }
}
