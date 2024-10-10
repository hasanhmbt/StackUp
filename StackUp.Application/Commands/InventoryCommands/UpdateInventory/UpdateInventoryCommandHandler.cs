using AutoMapper;
using MediatR;
using StackUp.Application.Commands.InventoryCommands;
using StackUp.Application.DTOs;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

//this class updated 

namespace StackUp.Application.CommandHandlers.InventoryHandlers
{
    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommand, InventoryDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInventoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<InventoryDTO> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork.Repository<Inventory>().GetByIdAsync(request.Id);
            if (inventory == null)
            {
                throw new KeyNotFoundException($"Inventory with Id {request.Id} not found.");
            }

            inventory.QuantityOnHand = request.QuantityOnHand;
            inventory.ReorderLevel = request.ReorderLevel;

            _unitOfWork.Repository<Inventory>().Update(inventory);
            await _unitOfWork.CommitAsync();

            var updatedInventory = await _unitOfWork.Repository<Inventory>().GetByIdAsync(inventory.Id);
            return _mapper.Map<InventoryDTO>(updatedInventory);
        }
    }
}
