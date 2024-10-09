using MediatR;

namespace StackUp.Application.Commands.OrderCommands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}
