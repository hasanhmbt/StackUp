using AutoMapper;
using MediatR;
using StackUp.Application.Commands.InventoryCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.CommandHandlers.InventoryHandlers
{
    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, InventoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InventoryDTO> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);
            await _unitOfWork.Repository<Inventory>().AddAsync(inventory);
            await _unitOfWork.CommitAsync();

            var createdInventory = await _unitOfWork.Repository<Inventory>().GetByIdAsync(inventory.Id);
            return _mapper.Map<InventoryDTO>(createdInventory);
        }
    }
}
