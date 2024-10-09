using MediatR;

namespace StackUp.Application.Commands.OrderDetailsCommands
{
    public class DeleteOrderDetailsCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteOrderDetailsCommand(int id)
        {
            Id = id;
        }
    }
}
