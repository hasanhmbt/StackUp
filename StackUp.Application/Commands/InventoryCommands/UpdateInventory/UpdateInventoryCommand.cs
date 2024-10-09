using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.InventoryCommands
{
    public class UpdateInventoryCommand : IRequest<InventoryDTO>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }

        public UpdateInventoryCommand(int id, int productId, int quantityOnHand, int reorderLevel)
        {
            Id = id;
            ProductId = productId;
            QuantityOnHand = quantityOnHand;
            ReorderLevel = reorderLevel;
        }
    }
}
