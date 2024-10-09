using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.InventoryCommands
{
    public class CreateInventoryCommand : IRequest<InventoryDTO>
    {
        public int ProductId { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }

        public CreateInventoryCommand(int productId, int quantityOnHand, int reorderLevel)
        {
            ProductId = productId;
            QuantityOnHand = quantityOnHand;
            ReorderLevel = reorderLevel;
        }
    }
}
