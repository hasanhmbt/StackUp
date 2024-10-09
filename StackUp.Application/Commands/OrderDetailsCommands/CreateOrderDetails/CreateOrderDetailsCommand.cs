using MediatR;
using StackUp.Application.DTOs;

namespace StackUp.Application.Commands.OrderDetails
{
    public class CreateOrderDetailsCommand : IRequest<OrderDetailsDTO>
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }

        public CreateOrderDetailsCommand(int productId, int quantity, int orderId)
        {
            ProductId = productId;
            Quantity = quantity;
            OrderId = orderId;
        }
    }
}
