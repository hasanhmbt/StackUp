using MediatR;

namespace StackUp.Application.Commands.SupplierCommands
{
    public class DeleteSupplierCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteSupplierCommand(int id)
        {
            Id = id;
        }
    }
}
