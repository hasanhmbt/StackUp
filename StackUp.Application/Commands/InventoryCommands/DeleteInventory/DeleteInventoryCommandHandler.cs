using MediatR;
using StackUp.Domain.Entities;
using StackUp.Domain.Interfaces;

namespace StackUp.Application.Commands.InventoryCommands.DeleteInventory
{
    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInventoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork.Repository<Inventory>().GetByIdAsync(request.Id);
            if (inventory == null)
            {
                throw new KeyNotFoundException($"Inventory with Id {request.Id} not found.");
            }

            _unitOfWork.Repository<Inventory>().Delete(inventory);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
