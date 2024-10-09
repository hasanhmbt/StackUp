using MediatR;

namespace StackUp.Application.Commands.ProductCommands
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteProductCommand(int id)
        {
            Id = id;
        }
    }
}
