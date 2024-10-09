using MediatR;

namespace StackUp.Application.Commands.InventoryCommands.DeleteInventory
{
    public class DeleteInventoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteInventoryCommand(int id)
        {
            Id = id;
        }
    }
}
