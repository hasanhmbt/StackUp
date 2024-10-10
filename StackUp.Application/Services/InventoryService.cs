using MediatR;
using StackUp.Application.Commands.InventoryCommands;
using StackUp.Application.Commands.InventoryCommands.DeleteInventory;
using StackUp.Application.DTOs;
using StackUp.Application.Queries.InventoryQueries;

namespace StackUp.Application.Services
{
    public class InventoryService
    {
        private readonly IMediator _mediator;

        public InventoryService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IEnumerable<InventoryDTO>> GetAllInventoriesAsync()
        {
            return await _mediator.Send(new GetAllInventoriesQuery());
        }

        public async Task<InventoryDTO> GetInventoryByIdAsync(int id)
        {
            return await _mediator.Send(new GetInventoryByIdQuery(id));
        }

        public async Task AddInventoryAsync(InventoryDTO inventoryDto)
        {
            var command = new CreateInventoryCommand(
                inventoryDto.ProductId,
                inventoryDto.QuantityOnHand,
                inventoryDto.ReorderLevel
            );
            await _mediator.Send(command);
        }

        public async Task UpdateInventoryAsync(int inventoryId, int newQuantityOnHand, int newReorderLevel)
        {
            var command = new UpdateInventoryCommand(
                inventoryId,
                newQuantityOnHand,
                newReorderLevel
            );
            await _mediator.Send(command);
        }

        public async Task RemoveInventoryAsync(int id)
        {
            var command = new DeleteInventoryCommand(id);
            await _mediator.Send(command);
        }
    }
}
