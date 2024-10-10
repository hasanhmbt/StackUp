using MediatR;
using StackUp.Application.DTOs;
//this class updated 

namespace StackUp.Application.Commands.InventoryCommands
{
    public class UpdateInventoryCommand : IRequest<InventoryDTO>
    {
        public int Id { get; set; }
        public int QuantityOnHand { get; set; }
        public int ReorderLevel { get; set; }

        public UpdateInventoryCommand(int id, int quantityOnHand, int reorderLevel)
        {
            Id = id;
            QuantityOnHand = quantityOnHand;
            ReorderLevel = reorderLevel;
        }
    }
}
