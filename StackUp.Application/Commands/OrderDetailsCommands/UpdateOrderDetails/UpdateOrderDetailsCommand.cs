using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.OrderDetails
{
    public class UpdateOrderDetailsCommand : IRequest<OrderDetailsDTO>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public UpdateOrderDetailsCommand(int id, int productId, int quantity)
        {
            Id = id;
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
